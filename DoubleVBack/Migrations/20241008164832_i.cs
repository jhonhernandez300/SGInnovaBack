using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoubleV.Migrations
{
    /// <inheritdoc />
    public partial class i : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId");
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoId);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tareas_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tareas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "ProyectoId", "Descripcion", "FechaFinalizacion", "FechaInicio", "Nombre", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Crear microservicio", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crear microservicio de prueba", null },
                    { 2, "Pruebas con jasmine", new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hacer pruebas unitarias en el front", null },
                    { 3, "Hacer pruebas con XUnit", new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hacer pruebas unitarias en el back", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Supervisor" },
                    { 3, "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Email", "Nombre", "Password", "RolId" },
                values: new object[,]
                {
                    { 1, "james@gmail.com", "James", "James0101*", 1 },
                    { 2, "radamel@gmail.com", "Radamel", "Radamel0101*", 3 },
                    { 3, "carlos@gmail.com", "Carlos", "Carlos0101*", 1 },
                    { 4, "maria@gmail.com", "Maria", "Maria0101*", 2 },
                    { 5, "luis@gmail.com", "Luis", "Luis0101*", 1 },
                    { 6, "laura@gmail.com", "Laura", "Laura0101*", 3 },
                    { 7, "andres@gmail.com", "Andres", "Andres0101*", 1 },
                    { 8, "daniela@gmail.com", "Daniela", "Daniela0101*", 2 },
                    { 9, "juan@gmail.com", "Juan", "Juan0101*", 1 },
                    { 10, "camila@gmail.com", "Camila", "Camila0101*", 2 },
                    { 11, "miguel@gmail.com", "Miguel", "Miguel0101*", 1 },
                    { 12, "sofia@gmail.com", "Sofia", "Sofia0101*", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "Descripcion", "Estado", "ProyectoId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Vender", "En Proceso", 1, 1 },
                    { 2, "Reparar", "Completada", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_UsuarioId",
                table: "Proyectos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_ProyectoId",
                table: "Tareas",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_UsuarioId",
                table: "Tareas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
