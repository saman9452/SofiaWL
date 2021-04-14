# Replication Package

The overall steps are

1. Install Relational Git
2. Get the Database
3. Run the Simulations
4. Dump the Simulation Data to CSV
5. Calculate the Expertise, Workload, and FaR measures

## Install Relational Git

1) [Install](https://github.com/fahimeh1368/SofiaWL/blob/gh-pages/install.md) the tool and its dependencies.

## Get the Database

1) Restore the backup of the data into MS Sql Server. For each studied project there is a separate database. You can select individual files from the [googledrive backup](https://drive.google.com/drive/folders/1nc7Hu7kbPpavYrCMmCU5SEBlLlZTo5Fv)
2) Copy the [configuration files](config).
3) Open and modify each configuration file to set the connection string. You need to provide the server address along with the credentials. The following snippet shows a sample of how connection string should be set.

```json
 {
	"ConnectionStrings": {
	  "RelationalGit": "Server=ip_db_server;User Id=user_name;Password=pass_word;Database=coreclr"
	},
	"Mining":{
 		
  	}
 }
```

4) Open [simulations.ps1](simulations.ps1) using an editor and make sure the config variables defined at the top of the file are reffering to the correct location of the downloaded config files. 

```powershell
# Each of the following variables contains the absolute path of the corresponding configuation file.
$corefx_conf = "absolute/path/to/corefx_conf.json"
$coreclr_conf = "absolute/path/to/coreclr_conf.json"
$roslyn_conf = "absolute/path/to/roslyn_conf.json"
$rust_conf = "absolute/path/to/rust_conf.json"
$kubernetes_conf = "absolute/path/to/kubernetes_conf.json"
```

## Run the Simulations

1) Run the [simulations.ps1](simulations.ps1) script. Open PowerShell and run the following command in the directory of the file

``` powershell
./simulations.ps1
```

This scripts runs all the defined reviewer recommendation algorithms accross all projects. Each run is called a simulation because for each pull request one of the actual reviewers is randomly selected to be replaced by the top recommended reviewer.

**Note**: Make sure you have set the PowerShell [execution policy](https://superuser.com/questions/106360/how-to-enable-execution-of-powershell-scripts) to **Unrestricted** or **RemoteAssigned**.

## Research Questions

In following sections, we show which simulations are used for which research questions. For each simulation, a sample is provided that illustrates how the simulation can be run using the tool.

### Empirical RQ1, Review and Turnover: What is the reduction in files at risk to turnover when both authors and reviewers are considered knowledgeable?


```PowerShell
# committers only
dotnet-rgit --cmd simulate-recommender --recommendation-strategy NoReviews --conf-path <path_to_config_file>
# committers + reviewers = what happended in "Reality"
dotnet-rgit --cmd simulate-recommender --recommendation-strategy Reality --conf-path <path_to_config_file>
```

Log into the database and run

```SQL
-- Get the Id of the simulation 
select Id, KnowledgeShareStrategyType, StartDateTime from LossSimulations
```

Using the Id returned from above, compare the knowlege loss with and without considering reviewers knowledgable run the following: 

```PowerShell
dotnet-rgit --cmd analyze-simulations --analyze-result-path "path_to_result" --no-reviews-simulation <no_reviews_sim_id> --reality-simulation <reality_sim_id>  --conf-path <path_to_config_file>
```

---

### Simulation RQ2, Ownership Aware: Does recommending reviewers based on code and review file ownership reduce the number of files at risk to turnover?

```PowerShell
# AuthorshipRec Recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy AuthorshipRec --conf-path <path_to_config_file>
# RevOwnRec Recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy RecOwnRec  --conf-path <path_to_config_file>
# cHRev Recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy cHRev --conf-path <path_to_config_file>
```

---

### Simulation RQ3, Turnover Aware: Can we reduce the number of files at risk to turnover by developing learning and retention aware review recommenders?

```PowerShell
# LearnRec Recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy LearnRec  --conf-path <path_to_config_file>
# RetentionRec Recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy RetentionRec  --conf-path <path_to_config_file>
# TurnoverRec Recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy TurnoverRec --conf-path <path_to_config_file>
# Sofia Recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy sofia  --conf-path <path_to_config_file>
```

---

### Empirical RQ4, Review Workload: How is the review workload distributed across developers?

```PowerShell
# Get each developer's number of open reviews in "day", "week", "month", "quarter", "year"
dotnet-rgit --cmd  get-workload --analyze-type <analyze-type> --analyze-result-path "path_to_result"  --reality-simulation <reality_id>  --conf-path <path_to_config_file>
```

To calculate the actual review workload run [ActualWorkload.r](WorkloadMeasures/ActualWorkload.R). The data from the paper is available in [CSV](ResultsCSV/WorkloadAUC/Actual/) format.

### Simulation RQ5, Workload Aware: WhoDo is designed to be workload aware, but can it also balance Expertise, Workload, and FarR

```PowerShell
#WhoDo recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy WhoDo  --conf-path <path_to_config_file>

```
---

### Simulation RQ6: Ownership, Turnover, and Workload Aware: Can we combine the recommenders to balance Expertise, Workload, and FaR?

```PowerShell
#SofiaWL recommender
dotnet-rgit --cmd simulate-recommender --recommendation-strategy SofiaWL  --conf-path <path_to_config_file>
```
---

## Dump the Simulation Data to CSV

Log into the database and run

```SQL
-- Get the Id of the simulation 
select Id, KnowledgeShareStrategyType, StartDateTime from LossSimulations
```

Substitute the Id returned above for the recommender \<rec_sim_id\> and compare the recommenders with the actual values, \<reality_id>.

```PowerShell
dotnet-rgit --cmd analyze-simulations --analyze-result-path "path_to_result" --recommender-simulation <rec_sim_id> --reality-simulation <reality_id>  --conf-path <path_to_config_file>
```

### Expertise and FAR results, and prior (ICSE) Workload measure results

The tool creates four csv files, **expertise.csv**, **far.csv**, **workload.csv** and **auc.csv**  respectively. In the first three files, the first column shows the project's periods (quarters). Each column corresponds to one of the simulations. Each cell shows the percentage change between the actual outcome and the simulated outcome in that period. The last row of a column shows the median of its values. Note the **workload.csv** file is the prior workload measure used in the original ICSE version of the paper. The following table illustrates how a csv file of a project with 5 periods is formatted, assuming that only cHRev, TurnoverRec, and Sofia got compared with reality.

| Periods       | cHRev         | cHRev         | TurnoverRec   | Sofia         |
| ------------- | ------------- | ------------- | ------------- |-------------- |
| 1  | 9.12  | 20 | 15  | 10  |
| 2  | 45.87  | 30  | 20  | 25  |
| 3  | 25.10  | 40  | 25  | 42  |
| 4  | 32.10  | 50  | 30  | 90  |
| 5  | 10.10  | 60  | 35  | 34.78  |
| Median  | 25.10  | 40  | 25  | 25  |

**Note**: During simulations, for each pull request, one reviewer is randomly selected to be replaced by the top recommended reviewer. 

### AUC CDF of Review Workload 

The file **auc.csv** from the prior step, shows the number of reviews of developers in each quarter. To calculate the AUC-based Workload measure run [WorkloadAUC.r](WorkloadMeasures/WorkloadAUC.R). The data from our simulations are in [CSV](ResultsCSV/WorkloadAUC/Simulated/).

