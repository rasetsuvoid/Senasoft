using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senasoft.Data.Migrations
{
    public partial class SegundaMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ciudades_IdCiudad",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Empleados_EmpleadoModelIdEmpleado",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Compra_Productos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Productos_Sucursal");

            migrationBuilder.DropTable(
                name: "Traslados");

            migrationBuilder.DropTable(
                name: "Ventas_Productos");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Provedores");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EmpleadoModelIdEmpleado",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdCiudad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmpleadoModelIdEmpleado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNac",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdCiudad",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoModelIdEmpleado",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNac",
                table: "AspNetUsers",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCiudad",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.IdCiudad);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Costo = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar", nullable: true),
                    NombreProducto = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Provedores",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Costo = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    nit = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    IdVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: true),
                    FechaVenta = table.Column<DateTime>(type: "date", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.IdVenta);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdCiudad = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.IdSucursal);
                    table.ForeignKey(
                        name: "FK_Sucursal_Ciudades_IdCiudad",
                        column: x => x.IdCiudad,
                        principalTable: "Ciudades",
                        principalColumn: "IdCiudad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFactura = table.Column<DateTime>(type: "date", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: true),
                    NumFac = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ProveedorModelIdProveedor = table.Column<int>(type: "int", nullable: true),
                    ValorTotalFactura = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_Provedores_ProveedorModelIdProveedor",
                        column: x => x.ProveedorModelIdProveedor,
                        principalTable: "Provedores",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cargo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cedula = table.Column<int>(type: "int", nullable: true),
                    IdSucursal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos_Sucursal",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    Existencias = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos_Sucursal", x => new { x.IdProducto, x.IdSucursal });
                    table.ForeignKey(
                        name: "FK_Productos_Sucursal_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Sucursal_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traslados",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdSucursalOrigen = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductosModelIdProducto = table.Column<int>(type: "int", nullable: true),
                    SucursalModelIdSucursal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traslados", x => new { x.IdProducto, x.IdSucursalOrigen });
                    table.ForeignKey(
                        name: "FK_Traslados_Productos_ProductosModelIdProducto",
                        column: x => x.ProductosModelIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Traslados_Sucursal_SucursalModelIdSucursal",
                        column: x => x.SucursalModelIdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ventas_Productos",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductosModelIdProducto = table.Column<int>(type: "int", nullable: true),
                    SucursalModelIdSucursal = table.Column<int>(type: "int", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    VentasModelIdVenta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas_Productos", x => new { x.IdProducto, x.IdSucursal, x.IdVenta });
                    table.ForeignKey(
                        name: "FK_Ventas_Productos_Productos_ProductosModelIdProducto",
                        column: x => x.ProductosModelIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Productos_Sucursal_SucursalModelIdSucursal",
                        column: x => x.SucursalModelIdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ventas_Productos_Ventas_VentasModelIdVenta",
                        column: x => x.VentasModelIdVenta,
                        principalTable: "Ventas",
                        principalColumn: "IdVenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compra_Productos",
                columns: table => new
                {
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ComprasModelIdCompra = table.Column<int>(type: "int", nullable: true),
                    IVA = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    ProductosModelIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra_Productos", x => new { x.IdCompra, x.IdProducto });
                    table.ForeignKey(
                        name: "FK_Compra_Productos_Compras_ComprasModelIdCompra",
                        column: x => x.ComprasModelIdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compra_Productos_Productos_ProductosModelIdProducto",
                        column: x => x.ProductosModelIdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EmpleadoModelIdEmpleado",
                table: "AspNetUsers",
                column: "EmpleadoModelIdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdCiudad",
                table: "AspNetUsers",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Productos_ComprasModelIdCompra",
                table: "Compra_Productos",
                column: "ComprasModelIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_Productos_ProductosModelIdProducto",
                table: "Compra_Productos",
                column: "ProductosModelIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ProveedorModelIdProveedor",
                table: "Compras",
                column: "ProveedorModelIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdSucursal",
                table: "Empleados",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Sucursal_IdSucursal",
                table: "Productos_Sucursal",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_IdCiudad",
                table: "Sucursal",
                column: "IdCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_Traslados_ProductosModelIdProducto",
                table: "Traslados",
                column: "ProductosModelIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Traslados_SucursalModelIdSucursal",
                table: "Traslados",
                column: "SucursalModelIdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Productos_ProductosModelIdProducto",
                table: "Ventas_Productos",
                column: "ProductosModelIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Productos_SucursalModelIdSucursal",
                table: "Ventas_Productos",
                column: "SucursalModelIdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Productos_VentasModelIdVenta",
                table: "Ventas_Productos",
                column: "VentasModelIdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ciudades_IdCiudad",
                table: "AspNetUsers",
                column: "IdCiudad",
                principalTable: "Ciudades",
                principalColumn: "IdCiudad",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Empleados_EmpleadoModelIdEmpleado",
                table: "AspNetUsers",
                column: "EmpleadoModelIdEmpleado",
                principalTable: "Empleados",
                principalColumn: "IdEmpleado",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
