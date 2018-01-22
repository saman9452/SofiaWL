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
    [Migration("20180111064629_RemovePullRequestReviewers")]
    partial class RemovePullRequestReviewers
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

                    b.Property<string>("BaseCommitSha");

                    b.Property<DateTime?>("ClosedAt");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("HtmlUrl");

                    b.Property<bool>("IsMerged");

                    b.Property<long>("IssueId");

                    b.Property<string>("IssueUrl");

                    b.Property<string>("MergeCommitSha");

                    b.Property<DateTime?>("MergedAt");

                    b.Property<int>("Number");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("PullRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
