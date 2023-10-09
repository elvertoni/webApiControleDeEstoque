﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using estoque.Data;

#nullable disable

namespace estoque.Migrations
{
    [DbContext(typeof(EstoqueContext))]
    [Migration("20231008205248_AtualizandoModels")]
    partial class AtualizandoModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("estoque.Models.CategoriaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FuncionarioModelId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioModelId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("estoque.Models.FornecedorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CNPJ")
                        .HasColumnType("longtext");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<int?>("FuncionarioModelId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FuncionarioModelId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("estoque.Models.FuncionarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .HasColumnType("longtext");

                    b.Property<bool>("Logado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("estoque.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int?>("FuncionarioModelId")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double?>("Preco")
                        .HasColumnType("double");

                    b.Property<double?>("QuantidadeEstoque")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioModelId");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("estoque.Models.CategoriaModel", b =>
                {
                    b.HasOne("estoque.Models.FuncionarioModel", null)
                        .WithMany("Categorias")
                        .HasForeignKey("FuncionarioModelId");
                });

            modelBuilder.Entity("estoque.Models.FornecedorModel", b =>
                {
                    b.HasOne("estoque.Models.CategoriaModel", "Categoria")
                        .WithMany("Fornecedores")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("estoque.Models.FuncionarioModel", null)
                        .WithMany("Fornecedores")
                        .HasForeignKey("FuncionarioModelId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("estoque.Models.ProdutoModel", b =>
                {
                    b.HasOne("estoque.Models.FuncionarioModel", null)
                        .WithMany("Produtos")
                        .HasForeignKey("FuncionarioModelId");

                    b.HasOne("estoque.Models.CategoriaModel", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("estoque.Models.FornecedorModel", "Fornecedor")
                        .WithMany("ProdutosFornecidos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("estoque.Models.CategoriaModel", b =>
                {
                    b.Navigation("Fornecedores");

                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("estoque.Models.FornecedorModel", b =>
                {
                    b.Navigation("ProdutosFornecidos");
                });

            modelBuilder.Entity("estoque.Models.FuncionarioModel", b =>
                {
                    b.Navigation("Categorias");

                    b.Navigation("Fornecedores");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
