namespace SC_601_PA_G5_M.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PA05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitaTallers",
                c => new
                    {
                        IdCita = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        FechaCita = c.DateTime(nullable: false),
                        DescripcionServicio = c.String(nullable: false, maxLength: 100),
                        EstadoCita = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdCita)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdUsuario = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        CorreoElectronico = c.String(nullable: false, maxLength: 50),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        Rol = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
            CreateTable(
                "dbo.DetallePedidoes",
                c => new
                    {
                        IdDetallePedidop = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetallePedidop)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        FechaPedido = c.DateTime(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        EstadoPedido = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdPedido);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false, maxLength: 100),
                        DescripcionProducto = c.String(nullable: false, maxLength: 100),
                        PrecioProducto = c.Double(nullable: false),
                        Existencias = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        NombreEmpleado = c.String(nullable: false, maxLength: 100),
                        PuestoEmpleado = c.String(nullable: false, maxLength: 50),
                        FechaContratacion = c.DateTime(nullable: false),
                        Salario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Transaccions",
                c => new
                    {
                        IdTransaccion = c.Int(nullable: false, identity: true),
                        FechaTransaccion = c.DateTime(nullable: false),
                        TipoTransaccion = c.String(nullable: false, maxLength: 25),
                        DescripcionTransaccion = c.String(nullable: false, maxLength: 100),
                        MontoTransaccion = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdTransaccion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallePedidoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetallePedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.CitaTallers", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.DetallePedidoes", new[] { "ProductoId" });
            DropIndex("dbo.DetallePedidoes", new[] { "PedidoId" });
            DropIndex("dbo.CitaTallers", new[] { "UsuarioId" });
            DropTable("dbo.Transaccions");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetallePedidoes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.CitaTallers");
        }
    }
}
