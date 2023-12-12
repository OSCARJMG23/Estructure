using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InititalMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria_persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre_categoria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paiss",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre_Paiss = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_contacto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "turno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre_turno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hora_turno_inicio = table.Column<float>(type: "float", nullable: true),
                    hora_turno_final = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre_dep = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_Paiss = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "departamento_ibfk_1",
                        column: x => x.id_Paiss,
                        principalTable: "Paiss",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokem_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UsuarioId, x.RolId });
                    table.ForeignKey(
                        name: "FK_userRol_rol_RolId",
                        column: x => x.RolId,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre_ciudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_dep = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "ciudad_ibfk_1",
                        column: x => x.id_dep,
                        principalTable: "departamento",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_persona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_registro = table.Column<DateOnly>(type: "date", nullable: true),
                    id_tipo_persona = table.Column<int>(type: "int", nullable: true),
                    id_categoria = table.Column<int>(type: "int", nullable: true),
                    id_ciudad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "persona_ibfk_1",
                        column: x => x.id_tipo_persona,
                        principalTable: "tipo_persona",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "persona_ibfk_2",
                        column: x => x.id_categoria,
                        principalTable: "categoria_persona",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "persona_ibfk_3",
                        column: x => x.id_ciudad,
                        principalTable: "ciudad",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contacto_persona",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_persona = table.Column<int>(type: "int", nullable: true),
                    id_contacto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "contacto_persona_ibfk_1",
                        column: x => x.id_persona,
                        principalTable: "persona",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contacto_persona_ibfk_2",
                        column: x => x.id_contacto,
                        principalTable: "tipo_contacto",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contrato",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    fecha_contrato = table.Column<DateOnly>(type: "date", nullable: true),
                    fecha_fin = table.Column<DateOnly>(type: "date", nullable: true),
                    id_cliente = table.Column<int>(type: "int", nullable: true),
                    id_empleado = table.Column<int>(type: "int", nullable: true),
                    id_estado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "contrato_ibfk_1",
                        column: x => x.id_cliente,
                        principalTable: "persona",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contrato_ibfk_2",
                        column: x => x.id_empleado,
                        principalTable: "persona",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "contrato_ibfk_3",
                        column: x => x.id_estado,
                        principalTable: "estado",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "programacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_contrato = table.Column<int>(type: "int", nullable: true),
                    id_turno = table.Column<int>(type: "int", nullable: true),
                    id_empleado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "programacion_ibfk_1",
                        column: x => x.id_contrato,
                        principalTable: "contrato",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "programacion_ibfk_2",
                        column: x => x.id_turno,
                        principalTable: "turno",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "programacion_ibfk_3",
                        column: x => x.id_empleado,
                        principalTable: "persona",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Paiss",
                columns: new[] { "id", "nombre_Paiss" },
                values: new object[] { 1, "Colombia" });

            migrationBuilder.InsertData(
                table: "categoria_persona",
                columns: new[] { "id", "nombre_categoria" },
                values: new object[,]
                {
                    { 1, "Auxiliar" },
                    { 2, "Cajero" },
                    { 3, "Supervisor" },
                    { 4, "Vigilante" }
                });

            migrationBuilder.InsertData(
                table: "estado",
                columns: new[] { "id", "descripcion" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Finalizado" },
                    { 3, "Pendiente" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "tipo_contacto",
                columns: new[] { "id", "descripcion" },
                values: new object[,]
                {
                    { 1, "Celular" },
                    { 2, "Email" }
                });

            migrationBuilder.InsertData(
                table: "tipo_persona",
                columns: new[] { "id", "descripcion" },
                values: new object[,]
                {
                    { 1, "Empleado" },
                    { 2, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "turno",
                columns: new[] { "id", "hora_turno_final", "hora_turno_inicio", "nombre_turno" },
                values: new object[,]
                {
                    { 1, 12f, 6f, "MaÃ±ana" },
                    { 2, 8f, 12f, "Tarde" },
                    { 3, 12f, 8f, "Noche" }
                });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "id", "id_Paiss", "nombre_dep" },
                values: new object[] { 1, 1, "Santander" });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "id", "id_dep", "nombre_ciudad" },
                values: new object[,]
                {
                    { 1, 1, "Bucaramanga" },
                    { 2, 1, "Floridablanca" },
                    { 3, 1, "Giron" },
                    { 4, 1, "Piedecuesta" }
                });

            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "id", "date_registro", "id_categoria", "id_ciudad", "id_persona", "id_tipo_persona", "nombre" },
                values: new object[,]
                {
                    { 1, new DateOnly(2009, 1, 11), 4, 3, "123459", 1, "Carlos David" },
                    { 2, new DateOnly(2011, 1, 11), null, 1, "123468", 2, "Karla Lopez" },
                    { 3, new DateOnly(2009, 1, 11), 1, 4, "123477", 1, "Hector Hernandez" },
                    { 4, new DateOnly(2013, 1, 11), null, 1, "123486", 2, "Juan Sanches" },
                    { 5, new DateOnly(2009, 1, 11), 4, 1, "123494", 1, "Pablo Gaviria" },
                    { 6, new DateOnly(2022, 1, 11), null, 3, "123505", 2, "Elon Musk" },
                    { 7, new DateOnly(2009, 1, 11), 4, 3, "123553", 1, "Leidy gaga" },
                    { 8, new DateOnly(2009, 1, 11), null, 1, "123741", 2, "Michael Jackson" },
                    { 9, new DateOnly(2009, 1, 11), 1, 4, "123562", 1, "Fredy Mercury" },
                    { 10, new DateOnly(2021, 1, 11), null, 1, "123635", 2, "Fredy Fasbear" },
                    { 11, new DateOnly(2009, 1, 11), 4, 3, "132456", 1, "Finn el Humano" }
                });

            migrationBuilder.InsertData(
                table: "contacto_persona",
                columns: new[] { "id", "descripcion", "id_contacto", "id_persona" },
                values: new object[,]
                {
                    { 1, "3132419732", 1, 1 },
                    { 2, "3132419732", 1, 2 },
                    { 3, "3132419732", 1, 3 },
                    { 4, "3132419732", 1, 4 },
                    { 5, "3132419732", 1, 5 },
                    { 6, "julian@gmial", 2, 6 },
                    { 7, "margi@gmial", 2, 7 },
                    { 8, "nico@gmial", 2, 8 },
                    { 9, "lalala@gmial", 2, 9 },
                    { 10, "sopas@gmial", 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "contrato",
                columns: new[] { "id", "fecha_contrato", "fecha_fin", "id_cliente", "id_empleado", "id_estado" },
                values: new object[,]
                {
                    { 1, new DateOnly(2009, 1, 11), new DateOnly(2023, 1, 11), 2, 1, 1 },
                    { 2, new DateOnly(2022, 2, 11), new DateOnly(2023, 2, 11), 4, 3, 1 },
                    { 3, new DateOnly(2022, 3, 11), new DateOnly(2023, 3, 11), 6, 5, 2 },
                    { 4, new DateOnly(2022, 4, 11), new DateOnly(2023, 4, 11), 8, 7, 1 },
                    { 5, new DateOnly(2022, 5, 11), new DateOnly(2023, 5, 11), 10, 9, 3 },
                    { 6, new DateOnly(2022, 6, 11), new DateOnly(2023, 6, 11), 2, 11, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "id_dep",
                table: "ciudad",
                column: "id_dep");

            migrationBuilder.CreateIndex(
                name: "id_contacto",
                table: "contacto_persona",
                column: "id_contacto");

            migrationBuilder.CreateIndex(
                name: "id_persona",
                table: "contacto_persona",
                column: "id_persona");

            migrationBuilder.CreateIndex(
                name: "id_cliente",
                table: "contrato",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "id_empleado",
                table: "contrato",
                column: "id_empleado");

            migrationBuilder.CreateIndex(
                name: "id_estado",
                table: "contrato",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "id_Paiss",
                table: "departamento",
                column: "id_Paiss");

            migrationBuilder.CreateIndex(
                name: "id_categoria",
                table: "persona",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "id_ciudad",
                table: "persona",
                column: "id_ciudad");

            migrationBuilder.CreateIndex(
                name: "id_tipo_persona",
                table: "persona",
                column: "id_tipo_persona");

            migrationBuilder.CreateIndex(
                name: "id_contrato",
                table: "programacion",
                column: "id_contrato");

            migrationBuilder.CreateIndex(
                name: "id_empleado1",
                table: "programacion",
                column: "id_empleado");

            migrationBuilder.CreateIndex(
                name: "id_turno",
                table: "programacion",
                column: "id_turno");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokem_UserId",
                table: "RefreshTokem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolId",
                table: "userRol",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacto_persona");

            migrationBuilder.DropTable(
                name: "programacion");

            migrationBuilder.DropTable(
                name: "RefreshTokem");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "tipo_contacto");

            migrationBuilder.DropTable(
                name: "contrato");

            migrationBuilder.DropTable(
                name: "turno");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "tipo_persona");

            migrationBuilder.DropTable(
                name: "categoria_persona");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "Paiss");
        }
    }
}
