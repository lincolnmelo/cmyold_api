## Start project:
dotnet run --project CMyOld_Api.WebUI


## Criar Migrations:
dotnet ef migrations add Inicial --project CMyOld_Api.Infra.Data -s CMyOld_Api.WebUI -c ApplicationDbContext --verbose

## Atualizar Migrations:
dotnet ef database update Inicial --project CMyOld_Api.Infra.Data -s CMyOld_Api.WebUI -c ApplicationDbContext --verbose

## Remover Migrations:
dotnet ef migrations remove --project CMyOld_Api.Infra.Data -s CMyOld_Api.WebUI -c ApplicationDbContext --verbose
