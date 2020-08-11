﻿// <auto-generated />
using System;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IncomeViz.ProfitCalculation.Migrations
{
    [DbContext(typeof(ProfitCalculationDbContext))]
    [Migration("20200505094412_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Expense.LongTerm.LongTermExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PredictionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("_effectiveDate")
                        .HasColumnName("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("_executionDay")
                        .HasColumnName("ExecutionDay")
                        .HasColumnType("int");

                    b.Property<string>("_name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PredictionId");

                    b.ToTable("LongTermExpenses","profitcalculation");
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm.ShortTermExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PredictionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("_executionDate")
                        .HasColumnName("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PredictionId");

                    b.ToTable("ShortTermExpenses","profitcalculation");
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Income.LongTerm.LongTermIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PredictionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("_effectiveDate")
                        .HasColumnName("EffectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("_executionDay")
                        .HasColumnName("ExecutionDay")
                        .HasColumnType("int");

                    b.Property<string>("_name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PredictionId");

                    b.ToTable("LongTermIncomes","profitcalculation");
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Income.ShortTerm.ShortTermIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PredictionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("_executionDate")
                        .HasColumnName("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PredictionId");

                    b.ToTable("ShortTermIncomes","profitcalculation");
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Prediction.Prediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_name")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("_startingDate")
                        .HasColumnName("StartingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Predictions","profitcalculation");
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Expense.LongTerm.LongTermExpense", b =>
                {
                    b.HasOne("IncomeViz.ProfitCalculation.Domain.Prediction.Prediction", "Prediction")
                        .WithMany("LongTermExpenses")
                        .HasForeignKey("PredictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("IncomeViz.ProfitCalculation.Domain.Money", "_money", b1 =>
                        {
                            b1.Property<int>("LongTermExpenseId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("_amount")
                                .HasColumnName("Amount")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<int>("_currency")
                                .HasColumnName("Currency")
                                .HasColumnType("int");

                            b1.HasKey("LongTermExpenseId");

                            b1.ToTable("LongTermExpenses");

                            b1.WithOwner()
                                .HasForeignKey("LongTermExpenseId");
                        });
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm.ShortTermExpense", b =>
                {
                    b.HasOne("IncomeViz.ProfitCalculation.Domain.Prediction.Prediction", "Prediction")
                        .WithMany("ShortTermExpenses")
                        .HasForeignKey("PredictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("IncomeViz.ProfitCalculation.Domain.Money", "_money", b1 =>
                        {
                            b1.Property<int>("ShortTermExpenseId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("_amount")
                                .HasColumnName("Amount")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<int>("_currency")
                                .HasColumnName("Currency")
                                .HasColumnType("int");

                            b1.HasKey("ShortTermExpenseId");

                            b1.ToTable("ShortTermExpenses");

                            b1.WithOwner()
                                .HasForeignKey("ShortTermExpenseId");
                        });
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Income.LongTerm.LongTermIncome", b =>
                {
                    b.HasOne("IncomeViz.ProfitCalculation.Domain.Prediction.Prediction", "Prediction")
                        .WithMany("LongTermIncomes")
                        .HasForeignKey("PredictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("IncomeViz.ProfitCalculation.Domain.Money", "_money", b1 =>
                        {
                            b1.Property<int>("LongTermIncomeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("_amount")
                                .HasColumnName("Amount")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<int>("_currency")
                                .HasColumnName("Currency")
                                .HasColumnType("int");

                            b1.HasKey("LongTermIncomeId");

                            b1.ToTable("LongTermIncomes");

                            b1.WithOwner()
                                .HasForeignKey("LongTermIncomeId");
                        });
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Income.ShortTerm.ShortTermIncome", b =>
                {
                    b.HasOne("IncomeViz.ProfitCalculation.Domain.Prediction.Prediction", "Prediction")
                        .WithMany("ShortTermIncomes")
                        .HasForeignKey("PredictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("IncomeViz.ProfitCalculation.Domain.Money", "_money", b1 =>
                        {
                            b1.Property<int>("ShortTermIncomeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("_amount")
                                .HasColumnName("Amount")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<int>("_currency")
                                .HasColumnName("Currency")
                                .HasColumnType("int");

                            b1.HasKey("ShortTermIncomeId");

                            b1.ToTable("ShortTermIncomes");

                            b1.WithOwner()
                                .HasForeignKey("ShortTermIncomeId");
                        });
                });

            modelBuilder.Entity("IncomeViz.ProfitCalculation.Domain.Prediction.Prediction", b =>
                {
                    b.OwnsOne("IncomeViz.ProfitCalculation.Domain.Money", "_startingMoney", b1 =>
                        {
                            b1.Property<int>("PredictionId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("_amount")
                                .HasColumnName("Amount")
                                .HasColumnType("decimal(18, 2)");

                            b1.Property<int>("_currency")
                                .HasColumnName("Currency")
                                .HasColumnType("int");

                            b1.HasKey("PredictionId");

                            b1.ToTable("Predictions");

                            b1.WithOwner()
                                .HasForeignKey("PredictionId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}