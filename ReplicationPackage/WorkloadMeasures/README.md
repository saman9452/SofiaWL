Please see the overall replication package [README](../README.md) for the full processing details. The steps here process the final CSV files to produce the final workload numbers and plots.

### Empirical RQ4, Review Workload: How is the review workload distributed across developers?

To calculate the actual review workload run [ActualWorkload.r](WorkloadMeasures/ActualWorkload.R). The data from the paper is available in [CSV](Data/Workload/Actual/) format.

### AUC CDF for simulated Review Workload for each recommender.

To calculate the AUC-based Workload measure run [WorkloadAUC.r](WorkloadMeasures/WorkloadAUC.R). The data from our simulations are in [CSV](Data/Workload/Simulated/).