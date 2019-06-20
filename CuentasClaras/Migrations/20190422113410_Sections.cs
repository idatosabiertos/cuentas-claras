using Microsoft.EntityFrameworkCore.Migrations;

namespace CuentasClaras.Migrations
{
    public partial class Sections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string table = "Buyers";
            const string name = "name";
            const string buyerExternalId = "buyerExternalId";

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 1, "Poder Legislativo" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 2, "Presidencia de la República" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 3, "Ministerio de Defensa Nacional" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 4, "Ministerio del Interior" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 5, "Ministerio de Economía y Finanzas" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 6, "Ministerio de Relaciones Exteriores" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 7, "Min.de Ganadería, Agricultura y Pesca" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 8, "Ministerio de Industria, Energía y Minería" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 9, "Ministerio de Turismo" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 10, "Ministerio de Transporte y Obras Públicas" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 11, "Ministerio de Educación y Cultura" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 12, "Ministerio de Salud Pública" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 13, "Ministerio de Trabajo y Seguridad Social" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 14, "M.de Vivienda, O.Territorial y M.Ambiente" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 15, "Ministerio de Desarrollo Social" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 16, "Poder Judicial" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 17, "Tribunal de Cuentas" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 18, "Corte Electoral" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 19, "Tribunal de lo Contencioso Administrativo" });

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 24, "Diversos Créditos" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 25, "Administración Nal. de Educación Pública" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 26, "Universidad de la República" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 27, "Instit.del Niño y Adolescente del Uruguay" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 28, "Banco de Previsión Social" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 29, "Adm.Servicios de Salud del Estado" });

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 31, "Universidad Tecnológica(UTEC)" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 32, "Instituto Uruguayo de Meteorología(INUMET)" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 33, "Fiscalía General de la Nación" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 34, "Junta de Transparencia y Ética Pública" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 35, "Inst.Nal.de Inclusión Social Adolescente" });

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 40, "Instituciones sin fines de lucro públicas" });

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 50, "Banco Central del Uruguay" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 51, "Banco de la Rep. Oriental del Uruguay" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 52, "Banco Hipotecario del Uruguay" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 53, "Banco de Seguros del Estado" });

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 60, "Adm.Nal.de Comb. Alcohol y Portland" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 61, "Adm.Nal.de Usinas y Trasm. Eléctricas" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 62, "Administración de Ferrocarriles del Estado" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 63, "Prim.Líneas Uruguayas de Nav. Aérea" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 64, "Administración Nacional de Puertos" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 65, "Administración Nal. de Telecomunicaciones" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 66, "Adm.de las Obras Sanitarias del Estado" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 67, "Adm.Nacional de Correos" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 68, "Agencia Nacional de Vivienda" });

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 70, "Instituto Nacional de Colonización" });

            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 80, "Gobierno Departamental de Artigas" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 81, "Gobierno Departamental de Canelones" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 82, "Gobierno Departamental de Cerro Largo" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 83, "Gobierno Departamental de Colonia" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 84, "Gobierno Departamental de Durazno" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 85, "Gobierno Departamental de Flores" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 86, "Gobierno Departamental de Florida" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 87, "Gobierno Departamental de Lavalleja" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 88, "Gobierno Departamental de Maldonado" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 89, "Gobierno Departamental de Paysandú" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 90, "Gobierno Departamental de Río Negro" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 91, "Gobierno Departamental de Rivera" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 92, "Gobierno Departamental de Rocha" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 93, "Gobierno Departamental de Salto" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 94, "Gobierno Departamental de San José" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 95, "Gobierno Departamental de Soriano" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 96, "Gobierno Departamental de Tacuarembó" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 97, "Gobierno Departamental de Treinta y Tres" });
            migrationBuilder.InsertData(table, new string[] { buyerExternalId, name }, new object[] { 98, "Gobierno Departamental de Montevideo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
