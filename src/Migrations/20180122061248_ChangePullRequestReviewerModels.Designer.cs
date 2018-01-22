﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace RelationalGit.Migrations
{
    [DbContext(typeof(GitRepositoryDbContext))]
    [Migration("20180122061248_ChangePullRequestReviewerModels")]
    partial class ChangePullRequestReviewerModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RelationalGit.Models.Commit", b =>
                {
                    b.Property<string>("Sha")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AuthorDateTime");

                    b.Property<string>("AuthorEmail");

                    b.Property<DateTime>("CommitterDateTime");

                    b.Property<string>("CommitterEmail");

                    b.Property<bool>("IsMergeCommit");

                    b.Property<string>("Message");

                    b.Property<string>("MessageShort");

                    b.Property<string>("TreeSha");

                    b.HasKey("Sha");

                    b.HasIndex("AuthorEmail");

                    b.HasIndex("CommitterEmail");

                    b.HasIndex("Sha");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("RelationalGit.Models.CommitBlobBlame", b =>
                {
                    b.Property<string>("DeveloperIdentity");

                    b.Property<string>("CommitSha");

                    b.Property<string>("CanonicalPath");

                    b.Property<int>("AuditedLines");

                    b.Property<double>("AuditedPercentage");

                    b.HasKey("DeveloperIdentity", "CommitSha", "CanonicalPath");

                    b.HasIndex("CanonicalPath");

                    b.HasIndex("CommitSha");

                    b.HasIndex("DeveloperIdentity");

                    b.ToTable("CommitBlobBlames");
                });

            modelBuilder.Entity("RelationalGit.Models.CommitPeriod", b =>
                {
                    b.Property<string>("CommitSha")
                        .HasMaxLength(40);

                    b.Property<long>("PeriodId");

                    b.HasKey("CommitSha", "PeriodId");

                    b.HasIndex("CommitSha");

                    b.HasIndex("PeriodId");

                    b.ToTable("CommitPeriods");
                });

            modelBuilder.Entity("RelationalGit.Models.CommitRelationship", b =>
                {
                    b.Property<string>("Parent");

                    b.Property<string>("Child");

                    b.HasKey("Parent", "Child");

                    b.ToTable("CommitRelationships");
                });

            modelBuilder.Entity("RelationalGit.Models.CommittedBlob", b =>
                {
                    b.Property<string>("CommitSha");

                    b.Property<string>("CanonicalPath");

                    b.Property<int>("NumberOfLines");

                    b.Property<string>("Path");

                    b.HasKey("CommitSha", "CanonicalPath");

                    b.HasIndex("CanonicalPath");

                    b.HasIndex("CommitSha");

                    b.ToTable("CommittedBlob");
                });

            modelBuilder.Entity("RelationalGit.Models.CommittedChange", b =>
                {
                    b.Property<string>("Path");

                    b.Property<string>("CommitSha");

                    b.Property<string>("CanonicalPath");

                    b.Property<string>("Oid");

                    b.Property<string>("OldOid");

                    b.Property<string>("OldPath");

                    b.Property<short>("Status");

                    b.HasKey("Path", "CommitSha");

                    b.HasIndex("CanonicalPath");

                    b.HasIndex("CommitSha");

                    b.HasIndex("Oid");

                    b.HasIndex("OldOid");

                    b.HasIndex("Path");

                    b.HasIndex("Status");

                    b.ToTable("CommittedChanges");
                });

            modelBuilder.Entity("RelationalGit.Models.Period", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstCommit");

                    b.Property<DateTime>("FromDateTime");

                    b.Property<string>("LastCommitSha");

                    b.Property<DateTime>("ToDateTime");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("RelationalGit.Models.PullRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BaseSha");

                    b.Property<DateTime?>("ClosedAtDateTime");

                    b.Property<DateTime?>("CreatedAtDateTime");

                    b.Property<string>("HtmlUrl");

                    b.Property<long>("IssueId");

                    b.Property<string>("IssueUrl");

                    b.Property<string>("MergeCommitSha");

                    b.Property<bool>("Merged");

                    b.Property<DateTime?>("MergedAtDateTime");

                    b.Property<int>("Number");

                    b.Property<string>("UserLogin");

                    b.HasKey("Id");

                    b.HasIndex("BaseSha");

                    b.HasIndex("MergeCommitSha");

                    b.HasIndex("Number");

                    b.ToTable("PullRequests");
                });

            modelBuilder.Entity("RelationalGit.Models.PullRequestFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Additions");

                    b.Property<int?>("Changes");

                    b.Property<int?>("Deletions");

                    b.Property<string>("FileName");

                    b.Property<string>("Oid");

                    b.Property<int>("PullRequestNumber");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("FileName");

                    b.HasIndex("PullRequestNumber");

                    b.ToTable("PullRequestFiles");
                });

            modelBuilder.Entity("RelationalGit.Models.PullRequestReviewer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommitId");

                    b.Property<long>("PullRequestNumber");

                    b.Property<string>("State");

                    b.Property<string>("UserLogin");

                    b.HasKey("Id");

                    b.HasIndex("CommitId");

                    b.HasIndex("PullRequestNumber");

                    b.ToTable("PullRequestReviewers");
                });

            modelBuilder.Entity("RelationalGit.Models.PullRequestReviewerComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("CommitId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("InReplyTo");

                    b.Property<string>("Path");

                    b.Property<int?>("PullRequestReviewId");

                    b.Property<string>("PullRequestUrl");

                    b.Property<string>("Url");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("CommitId");

                    b.HasIndex("Path");

                    b.HasIndex("PullRequestReviewId");

                    b.HasIndex("Username");

                    b.ToTable("PullRequestReviewerComments");
                });

            modelBuilder.Entity("RelationalGit.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
