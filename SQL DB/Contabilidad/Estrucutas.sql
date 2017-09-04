--use master
--Create database cnt drop database cnt
--drop table dbo.cntParametros 
--use cnt

  
 CREATE FUNCTION [dbo].[globalDiaDelMes] 
(-- @Cual = 'U' ultimo Dia 'P' Primemr
	@Fecha datetime,
	@Cual nvarchar(1)
	
)
RETURNS datetime
AS
BEGIN
DECLARE @Date DATETIME
if upper(@Cual) = 'P' --Primer Dia
	SET @date = (SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@Fecha)-1),@Fecha),111) AS Date_Value) 
if upper(@Cual) = 'U' --Ultimo Dia	
	SET @date = (SELECT CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@Fecha))),DATEADD(mm,1,@Fecha)),111))
	RETURN @Date
END
go

Create table dbo.cntTipoCuenta ( IDTipo int not null, Descr nvarchar(255), Tipo nvarchar(1), Activo bit default 1 )
go

alter table dbo.cntTipoCuenta add constraint pkTipoCuenta primary key (IDtipo)
go

Create table dbo.cntSubTipoCuenta ( IDTipo int not null, IDSubTipo int not null,  Descr nvarchar(255), 
SubTipo nvarchar(1), Activo bit default 1, Naturaleza nvarchar(1) )
go

alter table dbo.cntSubTipoCuenta add constraint pkcntSubTipoCuenta primary key (IDtipo, IDSubTipo)
go

alter table dbo.cntSubTipoCuenta add constraint fkcntSubTipoCuenta foreign key (IDtipo) references dbo.cntTipoCuenta ( IDtipo )
go

alter table dbo.cntSubTipoCuenta add constraint chkSubTipoCta CHECK ( Naturaleza in ('D', 'A'))
go
--*********** LOS TIPOS DE CUENTA SON VALORES POR DEFECTO DEL SISTEMA, SE TIENEN QUE INGRESAR AL CREAR LA BASE DE DATOS
insert dbo.cntTipoCuenta ( IDTipo, Descr, Tipo, Activo )
values (1, 'Balance de SituaciÛn', 'B', 1)
go

insert dbo.cntTipoCuenta ( IDTipo, Descr, Tipo, Activo )
values (2, 'Estado de Resultado', 'R', 1)
go

insert dbo.cntTipoCuenta ( IDTipo, Descr, Tipo, Activo )
values (3, 'Cuenta de Orden', 'O', 1)
go

insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (1,1,  'Activo', 'A', 1, 'D')
go

insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (1,2,  'Pasivo', 'P', 1, 'A')
go
 
insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (1,3,  'Patrimonio', 'T', 1, 'A')
go

insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (2,1,  'Ingreso', 'I', 1, 'A')
go

insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (2,2,  'Costos', 'C', 1, 'D')

insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (2,3,  'Gasto', 'G', 1, 'D')
go

Insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (3,1,  'Cuenta de Orden Deudora', 'O', 1, 'D')
go

Insert dbo.cntSubTipoCuenta ( IDTipo, IDSubTipo , Descr, SubTipo, Activo, Naturaleza  )
values (3,2,  'Cuenta de Orden Acreedora', 'O', 1, 'A')
go

 
Create Table dbo.cntGrupoCuenta ( 
IDGrupo int not null, 
Nivel1 nvarchar(10) not null, 
Descr nvarchar(255) not null, 
UsaComplementaria bit default 0, 
IDTipo int not null,
IDSubTipo int not null, 
Activo bit default 1)
go

alter table dbo.cntGrupoCuenta add constraint pkGrupo primary key (IDGrupo)
go

alter table dbo.cntGrupoCuenta add constraint fkTipo foreign key (IDTipo) references dbo.cntTipoCuenta (IDTipo)
go

alter table dbo.cntGrupoCuenta add constraint fksubGrupo foreign key (IDTipo, IDSubTipo) references dbo.cntSubTipoCuenta (IDTipo, IDSubTipo)
go

insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo )
values (1, '1', 'ACTIVOS',   0, 1,1)
GO

insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo)
values (2, '2', 'PASIVOS',   0,1,2)
GO

insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo)
values (3, '3', 'PATRIMONIO',   0,1,3)
GO

insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo)
values (4, '4', 'INGRESOS',   0,2,1)
GO

insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo)
values (5, '5', 'COSTOS',   0,2,3)
GO

insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo)
values (6, '6', 'GASTOS',   0,2,2)
GO


insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo)
values (8, '8', 'CUENTAS DE ORDEN DEUDORA',   0,3,1)
GO

insert  dbo.cntGrupoCuenta  (IDGrupo, Nivel1, Descr,   UsaComplementaria, IDTipo , IDSubTipo)
values (9, '9', 'CUENTAS DE ORDEN ACREEDORA',   0,3,2)
GO

Create Table dbo.cntCuenta ( 
IDCuenta int not null identity (1,1), 
IDGrupo int not null, 
IDTipo int not null,
IDSubTipo int not null, 
Tipo nvarchar(1) not null,
SubTipo nvarchar(1) not null, 
Nivel1 nvarchar(50)  default '', 
Nivel2 nvarchar(50)  default '', 
Nivel3 nvarchar(50)  default '', 
Nivel4 nvarchar(50)  default '' , 
Nivel5 nvarchar(50)  default '',
Cuenta nvarchar(50) not null default '', 
Descr nvarchar(255),
Complementaria bit default 0,
EsMayor bit default 0, 
AceptaDatos bit default 0,
Activa bit default 1, 
IDCuentaAnterior int not null,
IDCuentaMayor int not null,
UsaCentroCosto bit default 0
)
go


alter table dbo.cntCuenta add constraint chkMayorCentro CHECK ((cast(isnull(EsMayor,0) as int)+ cast(isnull(UsaCentroCosto,0) as int) )<=1)
go

alter table dbo.cntCuenta add constraint chkMayor CHECK ((cast(isnull(EsMayor,0) as int)+ cast(isnull(AceptaDatos,0) as int) )=1)
go
Alter Table dbo.cntCuenta add constraint pkcntCuenta primary key (IDCuenta)
go

Alter Table dbo.cntCuenta add constraint fkcntCuentaGrupo 
foreign key  (IDGrupo) references dbo.cntGrupoCuenta (IDGrupo)
go

Alter Table dbo.cntCuenta add constraint fkcntCuentaAnterior 
foreign key  (IDCuenta) references dbo.cntCuenta (IDCuenta)
go

Alter Table dbo.cntCuenta add constraint fkcntCuentaMayor 
foreign key  (IDCuenta) references dbo.cntCuenta (IDCuenta)
go


Create trigger trgCuenta on dbo.cntCuenta for Insert, Update
as
Declare @UsaSeparadorCta bit, @SeparadorCta nvarchar(1), @iCantidad int , @UsaPredecesor bit, @charPredecesor nvarchar(1), 
@cantCharNivel1 int,  @cantCharNivel2 int, @cantCharNivel3 int, @cantCharNivel4 int, @cantCharNivel5 int 

Select top 1 @UsaSeparadorCta = UsaSeparadorCta, @SeparadorCta = SeparadorCta, @UsaPredecesor = UsaPredecesor,
@charPredecesor = charPredecesor, @cantCharNivel1 = cantCharNivel1, @cantCharNivel2 = cantCharNivel2,
@cantCharNivel3 = cantCharNivel3, @cantCharNivel4 = cantCharNivel4, @cantCharNivel5 = cantCharNivel5
from  dbo.cntParametros


Update c set Cuenta = right(replicate ( @charPredecesor, @cantCharNivel1) +  ISNULL(i.Nivel1,'')  , @cantCharNivel1 ) + 
case when @UsaSeparadorCta= 1 and i.Nivel2<> '' then @SeparadorCta else '' end 
+ case when ISNULL(i.Nivel2,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel2)+ i.Nivel2, @cantCharNivel2)  else '' end 
+ case when @UsaSeparadorCta= 1 and i.Nivel3<> '' then @SeparadorCta else '' end
+ case when ISNULL(i.Nivel3,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel3)+ i.Nivel3, @cantCharNivel3)  else '' end
+ case when @UsaSeparadorCta= 1 and i.Nivel4<> '' then @SeparadorCta else '' end
+ case when ISNULL(i.Nivel4,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel4)+ i.Nivel4, @cantCharNivel4)  else '' end
+ case when @UsaSeparadorCta= 1 and i.Nivel5<> '' then @SeparadorCta else '' end
+ case when ISNULL(i.Nivel5,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel5)+ i.Nivel5, @cantCharNivel5)  else '' end

From inserted i inner join dbo.cntCuenta c
on i.IDGrupo = c.IDGrupo and i.IDCuenta = c.IDCuenta 

go


CREATE TABLE [dbo].[cntParametros](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UsaSeparadorCta] [bit] NULL,
	[SeparadorCta] [nvarchar](1) NULL,
	[UsaPredecesor] [bit] NULL,
	[charPredecesor] [nvarchar](1) NULL,
	[CantCharNivel1] [int] NULL,
	[CantCharNivel2] [int] NULL,
	[CantCharNivel3] [int] NULL,
	[CantCharNivel4] [int] NULL,
	[CantCharNivel5] [int] NULL,
	[IDCtaUtilidadPeriodo] [int] NULL,
	[IDCtaUtilidadAcumulada] [int] NULL,
	[MesInicioPeriodoFiscal] [int] NULL,
	[MesFinalPeriodoFiscal] [int] NULL,
	[UsaSeparadorCentro] [bit] NULL,
	[SeparadorCentro] [nvarchar](1) NULL,
	[UsaPredecesorCentro] [bit] NULL,
	[charPredecesorCentro] [nvarchar](1) NULL,
	[LongAsiento] [int] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[cntParametros]  WITH CHECK ADD  CONSTRAINT [fkctautilAcumPeriodo] FOREIGN KEY([IDCtaUtilidadAcumulada])
REFERENCES [dbo].[cntCuenta] ([IDCuenta])
GO

ALTER TABLE [dbo].[cntParametros] CHECK CONSTRAINT [fkctautilAcumPeriodo]
GO

ALTER TABLE [dbo].[cntParametros]  WITH CHECK ADD  CONSTRAINT [fkctautilperiodo] FOREIGN KEY([IDCtaUtilidadPeriodo])
REFERENCES [dbo].[cntCuenta] ([IDCuenta])
GO

ALTER TABLE [dbo].[cntParametros] CHECK CONSTRAINT [fkctautilperiodo]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__UsaSe__1ED998B2]  DEFAULT ((0)) FOR [UsaSeparadorCta]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__UsaPr__1FCDBCEB]  DEFAULT ((0)) FOR [UsaPredecesor]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__CantC__20C1E124]  DEFAULT ((0)) FOR [CantCharNivel1]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__CantC__21B6055D]  DEFAULT ((0)) FOR [CantCharNivel2]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__CantC__22AA2996]  DEFAULT ((0)) FOR [CantCharNivel3]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__CantC__239E4DCF]  DEFAULT ((0)) FOR [CantCharNivel4]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__CantC__24927208]  DEFAULT ((0)) FOR [CantCharNivel5]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__MesIn__25869641]  DEFAULT ((0)) FOR [MesInicioPeriodoFiscal]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__MesFi__267ABA7A]  DEFAULT ((0)) FOR [MesFinalPeriodoFiscal]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__UsaPr__276EDEB3]  DEFAULT ((0)) FOR [UsaPredecesorCentro]
GO

ALTER TABLE [dbo].[cntParametros] ADD  CONSTRAINT [DF__cntParame__LongA__286302EC]  DEFAULT ((10)) FOR [LongAsiento]
GO



insert dbo.cntParametros  ( UsaSeparadorCta, SeparadorCta, UsaPredecesor, charPredecesor, CantCharNivel1, CantCharNivel2,
CantCharNivel3, CantCharNivel4, CantCharNivel5, MesInicioPeriodoFiscal, MesFinalPeriodoFiscal,UsaSeparadorCentro, SeparadorCentro , UsaPredecesorCentro , charPredecesorCentro , LongAsiento    )
values ( 1, '-', 1,  '0',  1, 2,3,4, 5, 1, 12,1, '-', 1, '0', 10 )

go

Create  View  dbo.vcntCatalogo 
as 
SELECT C.IDGrupo, G.Descr DescrGrupo, C.IDCuenta, C.Nivel1, C.Nivel2, C.Nivel3, C.Nivel4, C.Nivel5,
C.Cuenta, C.Descr DescrCuenta, S.Naturaleza , 
case when c.Complementaria = 0 then S.Naturaleza 
else case when  s.naturaleza = 'D' then 'A' 
	 else 'D' 
	 end
end NaturalezaSaldo, 
 C.EsMayor, C.AceptaDatos , 
c.IDTipo, T.Descr DescrTipo,C.Tipo, C.IDSubTipo, S.Descr DescrSubTipo, S.SubTipo, 
C.Complementaria, C.UsaCentroCosto, C.IDCuentaMayor
FROM dbo.cntCuenta C INNER JOIN dbo.cntGrupoCuenta G on C.IDGrupo = G.IDGrupo 
inner join dbo.cntSubTipoCuenta S on C.IDTipo = s.IDTipo and C.IDSubTipo = S.IDSubTipo
inner join dbo.cntTipoCuenta T on C.IDTipo = T.IDTipo

go

Create Table dbo.cntEjercicio ( IDEjercicio int not null, Descr nvarchar(50), FechaInicio date, FechaFin date,
 Activo bit default 1, InicioOperaciones bit default 0, MesInicioOperaciones int, Cerrado bit default 0 ) 
go

alter table dbo.cntEjercicio add constraint pkcntEjercicio primary key (IDEjercicio)
go


alter table dbo.cntEjercicio add constraint chkperiodocierre check  ((Cerrado = 1 and activo = 1 ) or (Cerrado = 0 and Activo = 1) or (Cerrado = 0 and Activo = 0))
go


CREATE FUNCTION [dbo].[cntInicioOperaciones] ()
RETURNS bit
AS
BEGIN
Declare @Resultado int, @Iniciado bit 
set @Resultado = (
	Select COUNT(*)
	From dbo.cntEjercicio
	where InicioOperaciones = 1 --AND Activo = 1
	)
if @Resultado is null
	set @Resultado = 0
if @Resultado >= 1
	set @Iniciado = 1
else
	set @Iniciado = 0

RETURN @Iniciado
END
go


CREATE FUNCTION [dbo].[cntCantInicioOperaciones] ()
RETURNS int
AS
BEGIN
Declare @Resultado int, @Iniciado int 
set @Resultado = (
	Select COUNT(*)
	From dbo.cntEjercicio
	where InicioOperaciones = 1 AND Activo = 1
	)
if @Resultado is null
	set @Resultado = 0

	set @Iniciado = @Resultado

RETURN @Iniciado
END
go

CREATE FUNCTION [dbo].[cntCantEjerciciosAbiertos] ()
RETURNS int
AS
BEGIN
Declare @Resultado int, @Iniciado int 
set @Resultado = (
	Select COUNT(*)
	From dbo.cntEjercicio
	where Cerrado = 0 AND Activo = 1
	)
if @Resultado is null
	set @Resultado = 0

	set @Iniciado = @Resultado

RETURN @Iniciado
END
go


Alter Table dbo.cntEjercicio add constraint chkEjercicioInicioOperaciones 
check ( (not [dbo].[cntCantInicioOperaciones] ()>1 ) )				
go

Alter Table dbo.cntEjercicio add constraint chkEjercicioInicOperMesInicio 
check ( (InicioOperaciones = 1 and MesInicioOperaciones > 0) or (InicioOperaciones = 0 and MesInicioOperaciones = 0) )				
go


Alter Table dbo.cntEjercicio add constraint chkRangoAnio 
check ( DateDiff( day, FechaInicio, FechaFin) between 364 and 365 )				 
go
Create Table dbo.cntPeriodoContable ( IDEjercicio int not null, Periodo nvarchar(10) not null, FechaFinal date not null, Descr nvarchar(255) ,
FinPeriodoFiscal bit default 0, Cerrado bit default 0, AjustesCierreFiscal bit default 0, Activo bit default 1, PeriodoTrabajo bit default 0 )
go 

alter table dbo.cntPeriodoContable add constraint pkPeriodoContable primary key (IDEjercicio, Periodo)
go

alter table dbo.cntPeriodoContable add constraint fkPeriodoContable foreign key (IDEjercicio) references dbo.cntEjercicio ( IDEjercicio )
go


alter table dbo.cntPeriodoContable add constraint chkPeriodoContablecierre check  ((Cerrado = 1 and activo = 1 ) or (Cerrado = 0 and Activo = 1) or (Cerrado = 0 and Activo = 0))
go


Create Function dbo.cntEjercicioPeriodoDeTrabajo (@IDEjercicio int)
RETURNS int
BEGIN
Declare @Resultado int 
	set @Resultado =  ( Select count(*) 
				From dbo.cntPeriodoContable 
				Where IDEjercicio = @IDEjercicio and PeriodoTrabajo = 1 )	
		if @Resultado is null
			set @Resultado = 0

return @Resultado
END
go



Create Function dbo.cntEjercicioPeriodoAjusteCierreFiscal (@IDEjercicio int)
RETURNS int
BEGIN
Declare @Resultado int 
	set @Resultado =  ( Select count(*) 
				From dbo.cntPeriodoContable 
				Where IDEjercicio = @IDEjercicio and AjustesCierreFiscal = 1 )	
		if @Resultado is null
			set @Resultado = 0

return @Resultado
END
go

Create Function dbo.cntEjercicioPeriodoFinPeriodoFiscal (@IDEjercicio int)
RETURNS int
BEGIN
Declare @Resultado int 
	set @Resultado =  ( Select count(*) 
				From dbo.cntPeriodoContable 
				Where IDEjercicio = @IDEjercicio and FinPeriodoFiscal = 1 )	
		if @Resultado is null
			set @Resultado = 0

return @Resultado
END
go

Create Function dbo.cntEjercicioCntFinPeriodoFiscal (@IDEjercicio int)
RETURNS int
BEGIN
Declare @Resultado int 
	set @Resultado =  ( Select count(*) 
				From dbo.cntPeriodoContable 
				Where IDEjercicio = @IDEjercicio and FinPeriodoFiscal = 1 )	
		if @Resultado is null
			set @Resultado = 0

return @Resultado
END
go

--drop trigger trPeriodoContable
Create Trigger trPeriodoContable on dbo.cntPeriodoContable after Insert, Update
as
Declare @IDPeriodo int, @IDEjercicio int, @AjustesCierreFiscal bit, @FinPeriodoFiscal bit , @PeriodoTrabajo bit, @Activo bit
SElect @IDEjercicio = i.IDEjercicio, @AjustesCierreFiscal = i.AjustesCierreFiscal, @FinPeriodoFiscal = i.FinPeriodoFiscal,
@PeriodoTrabajo = PeriodoTrabajo, @Activo = Activo 
from inserted i
if @AjustesCierreFiscal = 1 and  dbo.cntEjercicioPeriodoAjusteCierreFiscal( @IDEjercicio)>1
begin
		RAISERROR ( 'Se intenta crear un Periodo Contable indicando que inicia Ajuste de Cierre Fiscal, pero ya Existe uno en ese Ejercicio...', 16, 1) ;
		rollback tran 
end

if @FinPeriodoFiscal = 1 and  dbo.cntEjercicioPeriodoFinPeriodoFiscal( @IDEjercicio)>1
begin
		RAISERROR ( 'Se intenta crear un Periodo Contable indicando que es Fin de Ciclo, pero ya Existe uno en ese Ejercicio...', 16, 1) ;
		rollback tran 
end

if @Activo = 0 and @PeriodoTrabajo = 1
begin
		RAISERROR ( 'Se intenta crear un Periodo Contable indicando que es Periodo de Trabajo, pero esta inactivo...', 16, 1) ;
		rollback tran 
end




go

Create Procedure dbo.cntCreaPeriodos @IDEjercicio int,  @AnioInicialPeriodo int
as
set nocount on
--set @AnioInicialPeriodo = 2017
Declare @MesInicioPeriodoFiscal int, @MesFinalPeriodoFiscal int, @MesPivote int, 
@Fecha date, @Periodo13 nvarchar(10), @Fecha13 date, @Periodo nvarchar(10), @FinPeriodo bit
Declare @InicioOperaciones bit, @MesInicioOperaciones int, @Activo bit 
 Select @InicioOperaciones= InicioOperaciones, @MesInicioOperaciones =MesInicioOperaciones
 from dbo.cntejercicio
 where IDEjercicio = @IDEjercicio
-- validar si no existe movimientos en cualquier periodos del anio
if @InicioOperaciones = 0
	set @Activo = 1
SElect Top 1 @MesInicioPeriodoFiscal = MesInicioPeriodoFiscal, @MesFinalPeriodoFiscal = MesFinalPeriodoFiscal   
from dbo.cntParametros

Delete from dbo.cntPeriodoContable where FechaFinal >=  cast (cast(@AnioInicialPeriodo as nvarchar(4) ) + right ('00'+ cast ( @MesInicioPeriodoFiscal as nvarchar(2) ),2) + '01' as datetime )
and  FechaFinal <= dateadd ( month, 12, cast (cast(@AnioInicialPeriodo as nvarchar(4) ) + right ('00'+ cast ( @MesInicioPeriodoFiscal as nvarchar(2) ),2) + '01' as datetime ) )

set @MesPivote = 1
	set @Fecha = cast (cast(@AnioInicialPeriodo as nvarchar(4) ) + right ('00'+ cast ( @MesInicioPeriodoFiscal as nvarchar(2) ),2) + '01' as datetime )
	--set @Fecha = (select  [dbo].[globalDiaDelMes] (DATEADD (month,11, @Fecha ), 'U'))
	set @Fecha =  (select  [dbo].[globalDiaDelMes](@Fecha, 'U'))
While @MesPivote <= 13
begin
	set @Periodo = cast(year(@Fecha) as nvarchar(4) ) + right ('00' + cast(month(@Fecha) as nvarchar(4) ),2) 
	set @FinPeriodo = 0
	if @MesPivote <= 12
	begin	
	if @InicioOperaciones = 1 and   @MesPivote< @MesInicioOperaciones
		set @Activo = 0
	else
		set @Activo = 1
	
	
		if @MesPivote = 12
			set @FinPeriodo = 1
			Insert dbo.cntPeriodoContable ( IDEjercicio, Periodo , FechaFinal, Descr, FinPeriodoFiscal, Activo)
			Values (@IDEjercicio, @Periodo, @Fecha, 'Periodo ' + @Periodo , @FinPeriodo, @Activo )
	end

	
	if @MesPivote = 13
	begin
		set @Periodo13  =(cast(year(@Fecha) as nvarchar(4) ) + '13' )
		-- esto estaba antes con fecha 1 del mes siguiente al ultimo mes del periodo
		--set @Fecha13 = DATEADD ( month, 1,  cast (cast(year(@Fecha) as nvarchar(4) )+ right('00'+ cast(month(@Fecha) as nvarchar(4) ),2)+ '01' as datetime ) )
		set @Fecha13 = @Fecha 

			Insert dbo.cntPeriodoContable ( IDEjercicio, Periodo , FechaFinal, Descr, FinPeriodoFiscal, AjustesCierreFiscal )
			Values (@IDEjercicio, @Periodo13, @Fecha13, 'Ajustes al Cierre Fiscal  ' + cast (@IDEjercicio as nvarchar(20)) , 0, 1)		
		
	end 

	set @MesPivote = @MesPivote + 1
	if @MesPivote <= 12
		set @Fecha = dateadd(month,1,@Fecha)
		set @Fecha =  (select  [dbo].[globalDiaDelMes](@Fecha, 'U'))
		
	
end

go

--******* para crear un EJERCICIO

Create Function dbo.cntExisteEjercicioConInicioOperaciones ()
Returns bit
begin
Declare @Existe bit
	set @Existe = (select  [dbo].[cntInicioOperaciones] ())
	Return @Existe
end
go
-- drop procedure dbo.cntCreaEjercicio exec dbo.cntCreaEjercicio  '20170101', 1,5 select * from cntperiodocontable select * from cntEjercicio
Create Procedure dbo.cntCreaEjercicio @FechaInicio date, @InicioOperaciones bit, @MesInicioOperaciones int
--Parametros del proceso de crear ejercicio 
-- @FechaInicio Es la Fecha en donde se inicia el Ejercicio de doce meses
-- @InicioOperaciones Indica si el ejercicio a crearse inicia o no las operaciones por primera vez
-- @MesInicioOperaciones Si es inicio de operaciones se indica el mes en que se inician las operaciones
as
Declare @FechaFin date,  @IDEjercicio int, @Anio int
set nocount on 
if dbo.cntExisteEjercicioConInicioOperaciones () = 1 and @InicioOperaciones = 1
begin
	RAISERROR ( 'Se intenta crear un Ejercicio Contable indicando que inicia operaciones, pero ya Existe uno...', 16, 1) ;
	return
end
 
if @InicioOperaciones = 0
	set  @MesInicioOperaciones = 0
Set  @FechaInicio = (select  [dbo].[globalDiaDelMes] ( @FechaInicio, 'P')) 
set @FechaFin = (select  [dbo].[globalDiaDelMes] (DATEADD (month,11, @FechaInicio ), 'U'))

set @Anio = (YEAR ( @FechaInicio ))

if exists (Select IDEjercicio from dbo.cntEjercicio where IDEjercicio = @Anio )
begin
	RAISERROR ( 'Ejercicio Contable Existente ...', 16, 1) ;
	return	
end
insert dbo.cntEjercicio ( IDEjercicio, Descr, FechaInicio, FechaFin , Activo, InicioOperaciones, MesInicioOperaciones)
values ( @Anio , 'Ejercicio ' + CAST( @Anio as nvarchar(4) ), @FechaInicio, @FechaFin,
1, @InicioOperaciones,@MesInicioOperaciones)
EXEC dbo.cntCreaPeriodos  @Anio, @Anio

go


Create Table dbo.cntCentroCosto ( IDCentro int identity(0,1) not null, Nivel1 nvarchar(2),  
Nivel2 nvarchar(2), Nivel3 nvarchar(2), Centro nvarchar(10), Descr nvarchar(255),
IDCentroAnterior int, Acumulador bit default 0,IDCentroAcumulador int,  ReadOnlySys bit default 0, Activo bit default 1)
go
Alter table dbo.cntCentroCosto add constraint pkCentro primary key (IDCentro)
go

alter table  dbo.cntCentroCosto add constraint fkCentroAcumulador foreign key (IDCentroAcumulador) references dbo.cntCentroCosto(IDCentro)
go

alter table  dbo.cntCentroCosto add constraint fkCentroAnterior foreign key (IDCentroAnterior) references dbo.cntCentroCosto(IDCentro)
go

alter table  dbo.cntCentroCosto add constraint ukcentroCentro unique (Centro)
go

Create trigger trgCentro on dbo.cntCentroCosto for Insert, Update
as
Declare @UsaSeparadorCentro bit, @SeparadorCentro nvarchar(1),  @UsaPredecesorCentro bit, @charPredecesorCentro nvarchar(1)

Select top 1 @UsaSeparadorCentro = UsaSeparadorCentro, @SeparadorCentro = SeparadorCentro, 
@UsaPredecesorCentro = UsaPredecesorCentro, @charPredecesorCentro = charPredecesorCentro
from  dbo.cntParametros


Update c set Centro = right(replicate ( @charPredecesorCentro, 2) +  ISNULL(i.Nivel1,'')  , 2 ) + 
case when @UsaSeparadorCentro= 1 and i.Nivel2<> '' then @SeparadorCentro else '' end 
+ case when ISNULL(i.Nivel2,'')<> '' then right (replicate ( @charPredecesorCentro, 2)+ isnull(i.Nivel2,''), 2)  else '' end 
+ case when @UsaSeparadorCentro= 1 and i.Nivel3<> '' then @SeparadorCentro else '' end
+ case when ISNULL(i.Nivel3,'')<> '' then right (replicate ( @charPredecesorCentro, 2)+ isnull(i.Nivel3,''), 2)  else '' end
From inserted i inner join dbo.cntCentroCosto c
on i.IDCentro = c.IDCentro

go


Insert dbo.cntCentroCosto ( Nivel1, Nivel2, Nivel3 , Descr ,  IDCentroAnterior, IDCentroAcumulador, Acumulador, ReadOnlySys )
values ( '0','0','0','No Definido', 0,0,0,1)
go


Create View dbo.vcntCentro
as
Select IDCentro, Centro, Descr, IDCentroAnterior, IDCentroAcumulador , Acumulador , ReadOnlySys , Activo
From dbo.cntCentroCosto 
go


Create Table dbo.cntCuentaCentro ( IDCuenta int not null, IDCentro int not null )
go

alter table dbo.cntCuentaCentro add constraint pkCentroCuenta primary key (IDCuenta, IDCentro)
go

alter table dbo.cntCuentaCentro add constraint fkCentroctacta foreign key (IDCuenta) references dbo.cntCuenta (IDCuenta)
go

alter table dbo.cntCuentaCentro add constraint fkCentroctaCentro foreign key (IDCentro) references dbo.cntCentroCosto (IDCentro)
go
-- drop table dbo.cntTipoAsiento
Create Table dbo.cntTipoAsiento( Tipo nvarchar(2) not null, Descr nvarchar(255), Consecutivo int default 0, UltimoAsiento nvarchar(20), Activo bit default 1, ReadOnlySys bit default 0)
go
alter table dbo.cntTipoAsiento add constraint pkTipoAsiento primary key (Tipo)
go
Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('FA', 'FACTURACION', 0, 'FA00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('CC', 'CUENTAS POR COBRAR', 0, 'CC00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('CP', 'CUENTAS POR PAGAR', 0, 'CP00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('NM', 'NOMINA', 0, 'NM00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('CG', 'CONTABILIDAD GENERAL', 0, 'CG00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('IN', 'INVENTARIO', 0, 'IN00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('CO', 'COMPRAS', 0, 'CO00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('AF', 'FACTIVOS FIJOS', 0, 'AF00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('BA', 'BANCOS', 0, 'BA00000000', 1, 1)
GO

Insert dbo.cntTipoAsiento (Tipo, Descr, Consecutivo, UltimoAsiento, Activo, ReadOnlySys)
values ('CF', 'CIERRE FISCAL ( EJERCICIO )', 0, 'CF00000000', 1, 1)
GO


Create Table dbo.cntAsiento ( IDEjercicio int not null, Periodo nvarchar(10) not null, Asiento nvarchar(20) not null, Tipo nvarchar(2) not null, Fecha date, FechaHora datetime,
Createdby nvarchar(20), CreateDate datetime, Mayorizadoby nvarchar(20), MayorizadoDate datetime,
Concepto nvarchar(255), Mayorizado bit default 0, Anulado bit default 0, TipoCambio decimal (28,4) default 0, ModuloFuente nvarchar(2), CuadreTemporal bit default 0 )
go

alter table  dbo.cntAsiento add constraint pkcntAsiento primary key (Asiento)
go

alter table  dbo.cntAsiento add constraint fkcntAsiento foreign key (Tipo) references dbo.cntTipoAsiento (Tipo)
go

alter table  dbo.cntAsiento add constraint fkcntAsientoEjercicio foreign key (IDEJercicio) references dbo.cntEjercicio (IDEjercicio)
go

alter table  dbo.cntAsiento add constraint fkcntAsientoPeriodo foreign key (IDEJercicio, Periodo) references dbo.cntPeriodoContable (IDEjercicio, Periodo)
go
alter table dbo.cntAsiento add constraint chkCuadretMayor CHECK ((cast(isnull(Mayorizado,0) as int)+ cast(isnull(CuadreTemporal,0) as int) ) IN (0,1))
go

-- Crear el codigo del asiento

Create Table dbo.cntAsientoDetalle ( Asiento nvarchar(20) not null, Linea int ,
IDCentro int not null, IDCuenta int not null, 
--Centro nvarchar(10) not null, 
--Cuenta nvarchar(50) not null,
Referencia nvarchar(255), Debito decimal (28,4) default 0,  Credito decimal (28,4) default 0,
Documento nvarchar(255), daterecord datetime default getdate()  )
go

alter table dbo.cntAsientoDetalle add constraint pkAsientoDetalle primary key (Asiento, IDCuenta, IDCentro)
go

alter table  dbo.cntAsientoDetalle add constraint fkcntAsientoCuenta foreign key (IDCuenta) references dbo.cntCuenta (IDCuenta)
go

alter table  dbo.cntAsientoDetalle add constraint fkcntAsientoCentro foreign key (IDCentro) references dbo.cntCentroCosto (IDCentro)
go

alter table  dbo.cntAsientoDetalle add constraint fkcntAsientodetasiento foreign key (Asiento) references dbo.cntAsiento(Asiento)
go

-- drop Trigger trgAsientoDetalle 
Create Trigger trgAsientoDetalle on dbo.cntAsientoDetalle for insert
as
Declare @Count int, @Asiento nvarchar(20) , @IDCentro int, @IDCuenta int, @Centro nvarchar(10), @Cuenta nvarchar(50)

SELECT @Asiento = i.Asiento, @IDCentro = IDCentro, @IDCuenta = IDCuenta
from inserted i 

--Select @Centro = Centro from dbo.cntCentroCosto  where IDCentro = @IDCentro
--Select @Cuenta = Cuenta from dbo.cntCuenta  where IDCuenta = @IDCuenta

set @Count = isnull((select  count(*) from dbo.cntAsientoDetalle where asiento =  @Asiento ) ,0)


update D set Linea = H.Linea
From  dbo.cntAsientoDetalle D inner join (SElect IDCuenta, IDCentro, ASiento, ROW_NUMBER() OVER(partition by Asiento ORDER BY IDCuenta, IDCentro, Asiento ASC) Linea
 From  dbo.cntAsientoDetalle D
WHERE D.Asiento = @Asiento 

) H
on D.IDCuenta = H.IDCuenta and D.IDCentro = H.IDCentro and D.Asiento = H.Asiento
--order by D.daterecord asc
go

-- drop table dbo.cntSaldo
Create Table dbo.cntSaldo( IDSaldo int not null Identity(1,1), IDEjercicio int not null, 
Periodo nvarchar(10) not null, IDCuenta int not null, IDCentro int not null,  Fecha date,  
Saldo decimal(28,4) default 0, Debito DECIMAL(28,4) DEFAULT 0 ,Credito DECIMAL(28,4) DEFAULT 0, TipoCambio decimal(28,4)  default 0,FechaSaldoAnt date, SaldoAnterior  decimal(28,4) default 0, TipoCambioSaldoAnt decimal(28,4)  default 0 )
go

alter table dbo.cntSaldo add constraint pkcntSaldo primary key (IDSaldo)
go

alter table dbo.cntSaldo add constraint ukcntSaldo UNIQUE (IDEjercicio, Periodo, IDCuenta, IDCentro, Fecha)
go

alter table dbo.cntSaldo add constraint fkcntSaldoEjerc foreign key (IDEjercicio) references dbo.cntEjercicio (IDEjercicio)
go

alter table dbo.cntSaldo add constraint fkcntSaldoPeriodo foreign key (IDEjercicio, Periodo) references dbo.cntPeriodoContable (IDEjercicio, Periodo)
go

alter table dbo.cntSaldo add constraint fkcntSaldoCta foreign key (IDCuenta) references dbo.cntCuenta (IDCuenta)
go

alter table dbo.cntSaldo add constraint fkcntSaldoCentro foreign key (IDCentro) references dbo.cntCentroCosto (IDCentro)
go

Create Table dbo.cntSeccionEstadoFinanciero ( IDSeccion int identity(1,1) not null, DescrEstadoFinanciero nvarchar (250), IDTIpo int not null, IDSubtipo int not null, Orden int default 0 )
 go

Alter table dbo.cntSeccionEstadoFinanciero  add constraint pkSeccionEF primary key (IDSeccion)
go

alter table dbo.cntSeccionEstadoFinanciero add constraint fkSeccionEFSubTipoCta foreign key (IDTipo, IDSubtipo) references dbo.cntSubTipoCuenta  (IDTipo, IDSubtipo) 
go

alter table dbo.cntCuenta add IDSeccion int 
go 

alter table dbo.cntCuenta add constraint fkCtaSeccion foreign key (IDseccion) references dbo.cntSeccionEstadoFinanciero (IDSeccion)
go

Create Procedure cntUpdateEjercicio @Operacion nvarchar(1), @IDEjercicio int = 0,  @FechaInicio datetime, @InicioOperaciones bit, @MesInicioOperaciones int, @Descr nvarchar(50) = null
as
set nocount on 

if upper(@Operacion) = 'U'
begin
	Update dbo.cntEjercicio set Descr = @Descr 
	where IDEjercicio = @IDEjercicio 
end


if upper(@Operacion) = 'I'
begin
	exec dbo.cntCreaEjercicio  @FechaInicio, @InicioOperaciones,@MesInicioOperaciones
end
if upper(@Operacion) = 'D'
begin
	if exists (Select IDEjercicio  from dbo.cntAsiento where IDEjercicio = @IDEjercicio)
	begin
			RAISERROR ( 'No se puede eliminar un ejercicio con movimientos contables...', 16, 1) ;
			return	
	end
	-- borrarlo
	BEGIN TRANSACTION 
	BEGIN TRY
		Delete from dbo.cntPeriodoContable  where IDEjercicio = @IDEjercicio
		Delete from dbo.cntEjercicio where IDEjercicio = @IDEjercicio
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0  
			ROLLBACK TRANSACTION;
	END CATCH
		IF @@TRANCOUNT > 0  
			COMMIT TRANSACTION; 	
end

go

Create Procedure dbo.cntUpdateTipoAsiento @Operacion nvarchar(1), @Tipo nvarchar(2), @Descr nvarchar(25), @Consecutivo int,  @Activo bit, @ReadOnlySys bit 
-- El ultimo asiento no se pasa como parametro
as
set nocount on 
declare @LongAsiento int, @tmpAsiento nvarchar (20)
	Select top 1  @LongAsiento = LongAsiento from dbo.cntParametros 	
	set @tmpAsiento = left(@Tipo + replicate ( '0', (@LongAsiento-2)),@LongAsiento)

if upper(@Operacion) = 'I'
begin
	if not exists (Select Tipo From dbo.cntTipoAsiento Where Tipo = @Tipo )
	begin
		insert dbo.cntTipoAsiento ( Tipo, Descr , Consecutivo ,Activo , ReadOnlySys, UltimoAsiento  )
		values ( @Tipo, @Descr, @Consecutivo, @Activo, @ReadOnlySys, @tmpAsiento )
	end
	else
	begin
			RAISERROR ( 'Ese Tipo de Asiento ya Existe', 16, 1) ;
			return			
	end
end	

if upper(@Operacion) in ('U', 'D') and Exists ( Select 	Tipo from  dbo.cntTipoAsiento  Where Tipo = @Tipo and ReadOnlySys = 1 )
begin
		RAISERROR ( 'Ese Tipo de Asiento est· protegido por el Sistema, Ud no puede alterarlo', 16, 1) ;
		return		
end

if upper(@Operacion) = 'U'
begin

	

	Update dbo.cntTipoAsiento set Descr = @Descr , Consecutivo = @Consecutivo, Activo = @Activo, ReadOnlySys = 0,
	UltimoAsiento = @tmpAsiento
	where Tipo = @Tipo and ReadOnlySys = 0
end	

if upper(@Operacion) = 'D'
begin

	if Exists ( Select 	Tipo from  dbo.cntAsiento  Where Tipo = @Tipo )	
	begin 
		RAISERROR ( 'Ese Tipo de Asiento no puede eliminarse porque tiene dependencias en asientos contables', 16, 1) ;
		return				
	end

	if Exists ( Select 	Tipo from  dbo.cntTipoAsiento  Where Tipo = @Tipo and ReadOnlySys = 0 )	
	begin 
		Delete from dbo.cntTipoAsiento where Tipo = @Tipo 
	end
end
go

Create Procedure dbo.cntUpdateCentroCosto @Operacion nvarchar(1), @IDCentro int, @Nivel1 nvarchar(2), @Nivel2 nvarchar(2),
@Nivel3 nvarchar(2), @Descr nvarchar(255), @IDCentroAnterior int, @Acumulador bit, @IDCentroAcumulador int
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT  dbo.cntCentroCosto ( Nivel1, Nivel2 , Nivel3 , Descr , IDCentroAnterior, Acumulador, IDCentroAcumulador )
	VALUES ( @Nivel1 , @Nivel2 , @Nivel3, @Descr , @IDCentroAnterior , @Acumulador , @IDCentroAcumulador )
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDCentro  from  dbo.cntCuentaCentro    Where IDCentro  = @IDCentro)	
	begin 
		RAISERROR ( 'Ese Centro de Costo no puede eliminarse porque tiene dependencias en la Relacion Cuentas - Centros', 16, 1) ;
		return				
	end
	if Exists ( Select IDCentro  from  dbo.cntAsientoDetalle   Where IDCentro  = @IDCentro)	
	begin 
		RAISERROR ( 'Ese Centro de Costo no puede eliminarse porque tiene dependencias en asientos contables', 16, 1) ;
		return				
	end
	DELETE  FROM dbo.cntCentroCosto WHERE IDCentro = @IDCentro and  ReadOnlySys <> 1
end

if upper(@Operacion) = 'U' 
begin
	Update dbo.cntCentroCosto set Descr = @Descr , Nivel1 = @Nivel1 , Nivel2 = @Nivel2 , Nivel3 = @Nivel3 ,
	Acumulador = @Acumulador ,  IDCentroAcumulador = @IDCentroAcumulador, IDCentroAnterior= @IDCentroAnterior
	where IDCentro = @IDCentro and ReadOnlySys <> 1
end

go

Create Procedure dbo.cntUpdateSeccionEstadoFinanciero @Operacion nvarchar(1), @IDSeccion int, @DescrEstadoFinanciero nvarchar(255), 
@IDTipo int, @IDSubTipo bit, @Orden int
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT  dbo.cntSeccionEstadoFinanciero ( DescrEstadoFinanciero, IDTipo , IDSubTipo , Orden )
	values ( @DescrEstadoFinanciero, @IDTipo , @IDSubTipo , @Orden)
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDCuenta  from  dbo.cntCuenta   Where IDSeccion  = @IDSeccion)	
	begin 
		RAISERROR ( 'Esa SecciÛn no puede eliminarse porque tiene dependencias en las Cuentas Contables', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.cntSeccionEstadoFinanciero WHERE IDSeccion  = @IDSeccion
end

if upper(@Operacion) = 'U' 
begin
	Update dbo.cntSeccionEstadoFinanciero set DescrEstadoFinanciero = @DescrEstadoFinanciero , Orden  = @Orden ,
	IDTipo = @IDTipo , IDSubTipo = @IDSubTipo 
	where IDSeccion  = @IDSeccion
end

go


Create Procedure dbo.cntSeteaCuentaAnterior @Activa bit
-- @Aciva = 0 ==> incluye cuentas activas e inactivos, @Activo = 1 solo activos
as
set nocount on
Create Table #CuentaAnterior (ID int identity(1,1) not null, IDCuenta int default 0, cuenta nvarchar(50), IDCuentaAnterior int default 0) 

insert #CuentaAnterior (IDCuenta, Cuenta )
select IDCuenta, Cuenta
from dbo.cntCuenta 
where (@Activa = 0 and Activa in (0,1) ) or (@Activa = 1 and Activa = @Activa )
order by Nivel1, Nivel2, Nivel3, Nivel4, nivel5

Update A set IDCuentaAnterior =  isnull(( Select  IDCuenta from #CuentaAnterior B where ( A.ID - 1 ) = B.ID ), 0 ) 
from #CuentaAnterior A 

Update C set IDCuentaAnterior = A.IDCuentaAnterior
from #CuentaAnterior A inner join dbo.cntCuenta C
on A.IDCuenta = C.IDCuenta 

drop table #CuentaAnterior

GO

CREATE Procedure dbo.cntUpdateCuenta @Operacion nvarchar(1), @IDCuenta int , @IDGrupo int , @IDTipo int , @Complementaria bit, 
@IDSubTipo int ,  @Nivel1 nvarchar(50)  , 
@Nivel2 nvarchar(50)  , @Nivel3 nvarchar(50) , @Nivel4 nvarchar(50)   , @Nivel5 nvarchar(50)  ,
 @Descr nvarchar(255),  @EsMayor bit , 
@AceptaDatos bit , @Activa bit , @IDCuentaAnterior int , @IDCuentaMayor int ,
@UsaCentroCosto bit, @IDSeccion int = null 
as
Declare @Tipo nvarchar(1) , @SubTipo nvarchar(1) , @UsaComplementaria bit, @Naturaleza nvarchar(1) 
set nocount on

Select @UsaComplementaria = UsaComplementaria 
from dbo.cntGrupoCuenta 
where IDGrupo = @IDGrupo 

select @Tipo = Tipo 
from dbo.cntTipoCuenta  
where IDTipo = @IDTipo 

Select @SubTipo = SubTipo, @Naturaleza = Naturaleza
from dbo.cntSubTipoCuenta 
where IDTipo = @IDTipo and IDSubTipo = @IDSubTipo 

if @Complementaria = 1
begin
	set @Naturaleza = case when @Naturaleza = 'D' then 'A' else 'D' end
end

if upper(@Operacion) = 'I'
begin
	INSERT  dbo.cntcuenta  (IDGrupo,IDTipo,IDSubTipo, Tipo, SubTipo , Nivel1, Nivel2, Nivel3, Nivel4 , Nivel5,  
							Descr, Complementaria , EsMayor , AceptaDatos, IDCuentaAnterior , IDCuentaMayor, 
							UsaCentroCosto , IDSeccion  ) 
	values ( @IDGrupo , @IDTipo , @IDSubTipo , @Tipo , @SubTipo , @Nivel1 , @Nivel2 , @Nivel3 , @Nivel4 , @Nivel5 , 
							@Descr, @Complementaria, @EsMayor, @AceptaDatos , @IDCuentaAnterior , @IDCuentaMayor,
							@UsaCentroCosto , @IDSeccion )
	exec dbo.cntSeteaCuentaAnterior	1						
end

if upper(@Operacion) = 'U'
begin
	Update dbo.cntcuenta set Descr = @Descr , Complementaria = @Complementaria , AceptaDatos = @AceptaDatos , Activa = @Activa , 
	IDCuentaAnterior = @IDCuentaAnterior , IDCuentaMayor = @IDCuentaMayor
	where IDCuenta = @IDCuenta 
end

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDCtaUtilidadAcumulada   from  dbo.cntParametros    Where (IDCtaUtilidadAcumulada   = @IDCuenta) or IDCtaUtilidadPeriodo= @IDCuenta )	
	begin 
		RAISERROR ( 'Esa Cuenta Contable no puede eliminarse porque tiene dependencias en los Parametros del Sistema', 16, 1) ;
		return				
	end
	if Exists ( Select IDCuenta   from  dbo.cntCuentaCentro   Where IDCuenta  = @IDCuenta)	
	begin 
		RAISERROR ( 'Esa Cuenta Contable no puede eliminarse porque tiene dependencias en la Relacion Cuentas - Centros', 16, 1) ;
		return				
	end
	if Exists ( Select IDcuenta  from  dbo.cntAsientoDetalle   Where IDCuenta  = @IDCuenta)	
	begin 
		RAISERROR ( 'La Cuenta no puede eliminarse porque tiene dependencias en asientos contables', 16, 1) ;
		return				
	end
	exec dbo.cntSeteaCuentaAnterior	1				
	Delete from dbo.cntcuenta Where IDCuenta = @IDCuenta 
end
go




--************ para grabar el Asiento Contable 
/*
DECLARE @XML xml
set @XML =
'<Root>
 <Asiento>
  <IDEjercicio>2017</IDEjercicio>
  <Periodo>201701</Periodo>
  <Asiento>FA0000000001</Asiento>
  <FechaHora>2017-01-02T00:00:00</FechaHora>
  <Tipo>FA</Tipo>
  <Createdby>azepeda</Createdby>
  <CreateDate>2017-01-01T00:00:00</CreateDate>
  <Modifiedby>azepeda</Modifiedby>
  <UpdatedDate>2017-01-01T00:00:00</UpdatedDate>
  <Concepto>APERTURA</Concepto>
  <Mayorizado>0</Mayorizado>
  <Anulado>0</Anulado>
  <TipoCambio>29.3000</TipoCambio>
  <CuadreTemporal>0</CuadreTemporal>
  <Detalle>
    <Asiento>FA0000000001</Asiento>
    <Linea>1</Linea>
    <IDCentro>0</IDCentro>
    <IDCuenta>5</IDCuenta>
    <Referencia>APERTURA</Referencia>
    <Debito>2500.0000</Debito>
    <Credito>0.0000</Credito>
    <Documento>APERTURA</Documento>
  </Detalle>
  <Detalle>
    <Asiento>FA0000000001</Asiento>
    <Linea>2</Linea>
    <IDCentro>0</IDCentro>
    <IDCuenta>6</IDCuenta>
    <Referencia>APERTURA</Referencia>
    <Debito>0.0000</Debito>
    <Credito>2500.0000</Credito>
    <Documento>APERTURA</Documento>
  </Detalle>
  <Detalle>
    <Asiento>FA0000000001</Asiento>
    <Linea>8</Linea>
    <IDCentro>0</IDCentro>
    <IDCuenta>7</IDCuenta>
    <Referencia>APERTURA</Referencia>
    <Debito>2500.0000</Debito>
    <Credito>2500.0000</Credito>
    <Documento>APERTURA</Documento>
  </Detalle>  
</Asiento>
</Root>'
--select @XML

exec dbo.cntUpdateAsientowithXML 'I', @XML , 'FA0000000001', 'FA'
select * from dbo.cntAsiento where Asiento = 'FA0000000005'
select * from dbo.cntAsientoDetalle  where Asiento = 'FA0000000005'
select * from dbo.cntTipoAsiento 
*/

--drop procedure dbo.cntUpdateAsientoWithXML 
ALTER procedure [dbo].[cntUpdateAsientoWithXML] @Operacion nvarchar(1), @XML xml, @Asiento nvarchar(20) OUTPUT, @Tipo nvarchar(2)
-- El Tipo se pasa para el proceso de insercion, para crear el numero del asiento en el tipo correspondiente...
as

set nocount on 
declare @LongAsiento INT , @Consecutivo int 

select @LongAsiento = LongAsiento from dbo.cntParametros 
-- LECTURA DE CABECERA 
select
    Tab.Col.value('IDEjercicio[1]', 'int') as IDEjercicio,
    Tab.Col.value('Periodo[1]', 'nvarchar(10)') as Periodo,
    Tab.Col.value('Asiento[1]', 'nvarchar(20)') as Asiento,
    --@Asiento Asiento, 
    Tab.Col.value('Tipo[1]', 'nvarchar(2)') as Tipo,
     Tab.Col.value('Fecha[1]', 'datetime') as Fecha,
    Tab.Col.value('FechaHora[1]', 'datetime') as FechaHora,
    Tab.Col.value('Createdby[1]', 'nvarchar(20)') as Createdby,
    Tab.Col.value('CreateDate[1]', 'datetime') as CreateDate,
    Tab.Col.value('Mayorizadoby[1]', 'nvarchar(20)') as Mayorizadoby,
    Tab.Col.value('MayorizadoDate[1]', 'datetime') as MayorizadoDate,
	Tab.Col.value('Concepto[1]', 'nvarchar(255)') as Concepto,
    Tab.Col.value('Mayorizado[1]', 'bit') as Mayorizado,
    Tab.Col.value('Anulado[1]', 'bit') as Anulado,
    Tab.Col.value('TipoCambio[1]', 'decimal(28,4)') as TipoCambio,
    Tab.Col.value('ModuloFuente[1]', 'nvarchar(2)') as ModuloFuente,
    Tab.Col.value('CuadreTemporal[1]', 'bit') as CuadreTemporal
into #Asiento
from @XML.nodes('//Root/Asiento') as Tab(Col)

-- LECTURA DE LINEAS DETALLE
select
	--@Asiento Asiento,  
	Tab1.Col1.value('Asiento[1]', 'nvarchar(20)') as Asiento,
    Tab1.Col1.value('Linea[1]', 'int') as Linea,
    Tab1.Col1.value('IDCentro[1]', 'int') as IDCentro,
    Tab1.Col1.value('IDCuenta[1]', 'int') as IDCuenta,
    --Tab1.Col1.value('Centro[1]', 'nvarchar(10)') as Centro,
    --Tab1.Col1.value('Cuenta[1]', 'nvarchar(50)') as Cuenta,
    Tab1.Col1.value('Referencia[1]', 'nvarchar(255)') as ReferenciaDet,
    Tab1.Col1.value('Debito[1]', 'float') as Debito,
    Tab1.Col1.value('Credito[1]', 'float') as Credito,
    Tab1.Col1.value('Documento[1]', 'nvarchar(255)') as Documento
into #AsientoDetalle    
from @XML.nodes('//Root/Detalle') as Tab1(Col1)



declare @msgDescuadre nvarchar(250), @Descuadrado bit
Select @Descuadrado = case when (SUM(Debito) <> sum(Credito) ) then  1 else 0 end,
@msgDescuadre = 'Debito: ' + cast(SUM(Debito) as nvarchar(20)) + 
' Credito: ' + cast(SUM(Credito) as nvarchar(20)) + ' Diferencia : ' + cast( SUM(Debito) - sum(Credito) as nvarchar(20)) 
From #AsientoDetalle

if Upper(@Operacion) in ('I', 'U')
begin 
	if  @Descuadrado  = 1
	begin
		begin
			declare @msg nvarchar(255)
			set @msg =  'El asiento Contable esta descuadrado ' + @msgDescuadre
			RAISERROR ( @msg , 16, 1) ;
			return		
		end

	end
end 
BEGIN TRANSACTION 
BEGIN TRY

	if upper(@Operacion) = 'D'
	begin
		if exists (Select Asiento From dbo.cntAsiento  where Asiento = @Asiento  and mayorizado = 1)
		begin
			RAISERROR ( 'Ese asiento contable no se puede eliminar porque ya ha sido mayorizado', 16, 1) ;
		
		end

			Delete From dbo.cntAsientoDetalle Where Asiento = @Asiento
			Delete From dbo.cntAsiento Where Asiento = @Asiento	

	end		

	if upper(@Operacion) = 'I'
	begin
 

			 	SELECT @Asiento = (tipo + RIGHT( replicate('0', @LongAsiento ) + cast (Consecutivo + 1 as nvarchar(20)), @LongAsiento ) ),
 				@Consecutivo = Consecutivo + 1     
				FROM dbo.cntTipoAsiento (UPDLOCK)                             
				WHERE TIPO = @Tipo
				if exists (Select Asiento From dbo.cntAsiento (NOLOCK)  where Asiento = @Asiento )
				begin
					RAISERROR ( 'Ya Existe ese asiento contable, no se puede crear', 16, 1) ;		
				end	
				Update dbo.cntTipoAsiento set UltimoAsiento = @Asiento , Consecutivo = @Consecutivo 		 			
				where Tipo = @Tipo 
					
				INSERT  dbo.cntAsiento ( IDEjercicio, Periodo, Asiento, Tipo, Fecha,FechaHora, Createdby, CreateDate, Concepto, Mayorizado,
				Anulado, TipoCambio, ModuloFuente, CuadreTemporal  )
				Select IDEjercicio, Periodo, @Asiento Asiento, Tipo,CAST( Fecha as DATE)  Fecha, FechaHora, Createdby, CreateDate, Concepto, Mayorizado,
				Anulado, TipoCambio, ModuloFuente, CuadreTemporal
				From #Asiento 
				--where asiento = @Asiento Linea ,Linea ,

				INSERT dbo.cntAsientoDetalle( Asiento,  IDCentro, IDCuenta ,  Referencia , Debito, Credito , Documento )
				Select @Asiento Asiento,  IDCentro, IDCuenta ,  ReferenciaDet , Debito, Credito , Documento 
				from #AsientoDetalle 
				--where asiento = @Asiento 
		
				--return
	end	
	
	if upper(@Operacion) = 'U'
	begin

		if exists (Select Asiento From dbo.cntAsiento  where Asiento = @Asiento  and mayorizado = 1)
		begin
			RAISERROR ( 'Ese asiento contable no se puede editar porque ya ha sido mayorizado', 16, 1) ;
			--return		
		end

			Delete From dbo.cntAsientoDetalle Where Asiento = @Asiento
			Delete From dbo.cntAsiento Where Asiento = @Asiento	
			
				INSERT  dbo.cntAsiento ( IDEjercicio, Periodo, Asiento, Tipo, Fecha,FechaHora, Createdby, CreateDate, Concepto, Mayorizado,
				Anulado, TipoCambio, ModuloFuente, Mayorizadoby, MayorizadoDate )
				Select IDEjercicio, Periodo, @Asiento Asiento, Tipo,CAST( Fecha as DATE)  Fecha, FechaHora, Createdby, CreateDate, Concepto, Mayorizado,
				Anulado, TipoCambio, ModuloFuente, Mayorizadoby, MayorizadoDate
				From #Asiento 
				--where asiento = @Asiento 
			
				INSERT dbo.cntAsientoDetalle( Asiento, Linea , IDCentro, IDCuenta ,  Referencia , Debito, Credito , Documento )
				Select @Asiento Asiento, Linea , IDCentro, IDCuenta ,  ReferenciaDet , Debito, Credito , Documento 
				from #AsientoDetalle 
				--where asiento = @Asiento		
		

	end		
END TRY
BEGIN CATCH
	declare @error nvarchar(500)
    SELECT @error = ERROR_MESSAGE()  
    RAISERROR ( @error, 16, 1) ;
	IF @@TRANCOUNT > 0  
		ROLLBACK TRANSACTION;
END CATCH
	IF @@TRANCOUNT > 0  
		COMMIT TRANSACTION; 	


drop table #AsientoDetalle
drop table #Asiento
 



go

-- drop procedure dbo.cntGetPeriodoFromEjercicio
Create Procedure dbo.cntGetPeriodoFromEjercicio (@IDEjercicio int output, @Periodo nvarchar(10) output, @Tipo nvarchar(1) )
-- @Tipo 'I' Inicio 'A' anterior 'F' Final
as
set nocount on 
declare @PeriodoResultado nvarchar(10)
if UPPER ( @Tipo ) = 'A' 
	select @PeriodoResultado =  substring (Periodo, 1,4 ) +RIGHT ( '0' + cast ( cast(substring (Periodo, 5,2 ) as int ) - 1 as nvarchar(10)) ,2)  
	from dbo.cntPeriodoContable 
	where IDEjercicio = @IDEjercicio and Periodo = @Periodo
if UPPER ( @Tipo ) = 'I' 	
	select TOP 1  @PeriodoResultado = MIN(Periodo) --, 1,4 ) + '01'
	from dbo.cntPeriodoContable 
	where IDEjercicio = @IDEjercicio --and Periodo = @Periodo
if UPPER ( @Tipo ) = 'F'
	select TOP 1 @PeriodoResultado = MAX(Periodo) --, 1,4 ) + '12'
	from dbo.cntPeriodoContable 
	where IDEjercicio = @IDEjercicio AND FINPERIODOFISCAL = 1 --and Periodo = @Periodo	
	
	if 	substring (@PeriodoResultado, 5,2 ) = '00'
	begin
		set @PeriodoResultado = cast(@IDEjercicio-1 as nvarchar(4))+ '13'
		set @IDEjercicio = @IDEjercicio-1
	end

	set @Periodo = 	@PeriodoResultado
		
go

Create View dbo.vcntAsiento
as 
Select A.IDEjercicio, A.Periodo, A.Asiento , A.Tipo , A.Fecha, A.FechaHora, A.Createdby, A.CreateDate, A.Concepto, 
A.Mayorizado, A.TipoCambio, A.ModuloFuente, A.CuadreTemporal, D.Linea , D.IDCuenta, D.IDCentro, D.Debito, D.Credito , D.Referencia ,
D.Documento, D.daterecord, A.Anulado 
from dbo.cntAsiento A INNER JOIN dbo.cntAsientoDetalle D
on A.Asiento = D.Asiento
go


-- Calcular Saldo de Una Cuenta
-- drop procedure dbo.cntGetSaldo
Create Procedure dbo.cntGetSaldo  @IDCuenta int, @IDCentro int, @IDEjercicio int, @Periodo nvarchar(10), @Fecha date output,
 @Saldo decimal (28,4) output, @TipoCambio decimal (28,4) output
as
set nocount on 

Select @Fecha = Fecha,  @Saldo = Saldo, @TipoCambio = TipoCambio
-- Cuando haga falta agregarlos... este es el saldo anterior del ciclo pasado por parametro
--, @FechaSaldoAnterior = FechaSaldoAnt,  @SaldoAnterior = SaldoAnterior, @TipoCambioSaldoAnt = TipoCambioSaldoAnt
From dbo.cntSaldo (nolock)
Where IDEjercicio = @IDEjercicio  and IDCuenta = @IDCuenta and IDCentro = @IDCentro 
and  Periodo = @Periodo

if @Fecha is null
	set @Fecha = '19800101'

if @TipoCambio is null
	set @TipoCambio = 1

if @Saldo is null
	set @Saldo = 0

if @TipoCambio is null
	set @TipoCambio = 0

go

-- drop procedure dbo.cntGetMovimiento
Create Procedure dbo.cntGetMovimiento @IDCuenta int, @IDCentro int, @IDEjercicio int, @Periodo nvarchar(10),
@SoloMayor bit = true , 
@Debito decimal (28,4 ) output, @Credito decimal (28,4 ) output, @Movimiento decimal (28,4 ) output, @Naturaleza nvarchar(1) output
as 
set nocount on 

select @Naturaleza = NaturalezaSaldo  
from dbo.vcntCatalogo 
where IDCuenta = @IDCuenta


Select top 1 @Debito = isnull(SUM(Debito ),0) , @Credito = ISNULL( SUM(Credito ),0) ,  
@Movimiento = isnull(SUM(case when @Naturaleza = 'D' THEN Debito - Credito else Credito - Debito end ),0) 
from dbo.vcntasiento
where IDEjercicio = @IDEjercicio  and Periodo = @Periodo and  IDCuenta = @IDCuenta and IDCentro = @IDCentro 
and Anulado = 0 and ( ( Mayorizado = 1)  or (@SoloMayor = 0 and Mayorizado = 0) )
Group by IDEjercicio, IDCuenta, IDCentro   

go 


-- Parametros del stored procedure  drop procedure dbo.cntGetSaldoAcumulado
Create Procedure dbo.cntGetSaldoAcumulado @IDEjercicio int, @Periodo nvarchar(10), @IDCuenta int, @IDCentro int, @SoloMayor bit = 1
as
set nocount on 
declare  @Fecha date,@Saldo decimal (28,4) , @TipoCambio decimal (28,2), @IDEjercicioAnt int, @PeriodoAnt nvarchar(10)
declare @Debito decimal (28,4 ) , @Credito decimal (28,4 ) , @Movimiento decimal (28,4 ), @Naturaleza nvarchar(1)
declare @DescrCta nvarchar(255), @Cuenta nvarchar(50), @Centro nvarchar(10)
set @IDEjercicioAnt = @IDEjercicio
set @PeriodoAnt = @Periodo

exec dbo.cntGetPeriodoFromEjercicio @IDEjercicioAnt  output, @PeriodoAnt output, 'A'
exec dbo.cntGetSaldo   @IDCuenta, @IDCentro, @IDEjercicioAnt, @PeriodoAnt , @Fecha output,@Saldo output, @TipoCambio output
exec dbo.cntGetMovimiento @IDCuenta , @IDCentro , @IDEjercicio , @Periodo ,
 @SoloMayor , 
@Debito output , @Credito output  , @Movimiento  output, @Naturaleza output 

select @DescrCta = DescrCuenta, @Cuenta = Cuenta
from dbo.vcntCatalogo 
where IDCuenta = @IDCuenta 

Select @Centro = Centro  From dbo.vcntCentro where IDCentro = @IDCentro

select @IDCuenta IDCuenta, @Cuenta Cuenta, @DescrCta DescrCta, @Naturaleza Naturaleza, @IDCentro IDCentro, @Centro Centro,
 @Fecha fecha, isnull(@TipoCambio,0) TipoCambio, isnull(@Saldo,0) SaldoInicial, isnull(@Debito,0) Debito, isnull(@Credito,0) Credito, isnull(@Movimiento,0) SaldoMes, (isnull(@Saldo,0) + isnull(@Movimiento,0)) SaldoAcumulado

go
-- Se le pasa -1 para el nivel que quiero tomar el maximo
CREATE FUNCTION [dbo].[cntGetNextConsecutivoCuenta] (@Nivel1 AS INT,@Nivel2 AS INT,@Nivel3 AS INT,@Nivel4 AS INT,@Nivel5 AS INT)
RETURNS int
AS
BEGIN
Declare @Resultado BIGINT

set @Resultado = (
	SELECT CASE  WHEN @Nivel1=-1 THEN MAX(CAST(Nivel1 AS bigint))
					WHEN @Nivel2=-1 THEN	MAX(CAST(Nivel2 AS bigint))
					WHEN @Nivel3=-1 THEN MAX(CAST(Nivel3 AS bigint))
					WHEN @Nivel4=-1 THEN MAX(CAST(Nivel4 AS bigint))
					WHEN @Nivel5=-1 THEN MAX(CAST(Nivel5 AS bigint))
					END  Consecutivo  FROM dbo.cntCuenta 
	WHERE (Nivel1=@Nivel1 OR @Nivel1=-1) 
	AND (Nivel2=@Nivel2 OR @Nivel2=-1)
	AND (Nivel3=@Nivel3 OR @Nivel3=-1)
	AND (Nivel4=@Nivel4 OR @Nivel4=-1)
	AND (Nivel5=@Nivel5 OR @Nivel5=-1)
	)
if @Resultado is null
	set @Resultado = 0

	

RETURN @Resultado
END

GO


CREATE FUNCTION [dbo].[cntGetMascaraCuentaByNivel] (@Nivel1 AS NVARCHAR(50),@Nivel2 AS NVARCHAR(50),@Nivel3 AS NVARCHAR(50),@Nivel4 AS NVARCHAR(50),@Nivel5 AS NVARCHAR(50))
RETURNS NVARCHAR(50)
AS
BEGIN

Declare @Resultado NVARCHAR(50)
Declare @UsaSeparadorCta bit, @SeparadorCta nvarchar(1), @iCantidad int , @UsaPredecesor bit, @charPredecesor nvarchar(1), 
@cantCharNivel1 int,  @cantCharNivel2 int, @cantCharNivel3 int, @cantCharNivel4 int, @cantCharNivel5 int 


Select top 1 @UsaSeparadorCta = UsaSeparadorCta, @SeparadorCta = SeparadorCta, @UsaPredecesor = UsaPredecesor,
@charPredecesor = charPredecesor, @cantCharNivel1 = cantCharNivel1, @cantCharNivel2 = cantCharNivel2,
@cantCharNivel3 = cantCharNivel3, @cantCharNivel4 = cantCharNivel4, @cantCharNivel5 = cantCharNivel5
from  dbo.cntParametros
	
set @Resultado = (
	
SELECT right(replicate ( @charPredecesor, @cantCharNivel1) +  ISNULL(@Nivel1,'')  , @cantCharNivel1 ) + 
case when @UsaSeparadorCta= 1 and @Nivel2<> '' then @SeparadorCta else '' end 
+ case when ISNULL(@Nivel2,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel2)+ @Nivel2, @cantCharNivel2)  else '' end 
+ case when @UsaSeparadorCta= 1 and @Nivel3<> '' then @SeparadorCta else '' end
+ case when ISNULL(@Nivel3,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel3)+ @Nivel3, @cantCharNivel3)  else '' end
+ case when @UsaSeparadorCta= 1 and @Nivel4<> '' then @SeparadorCta else '' end
+ case when ISNULL(@Nivel4,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel4)+ @Nivel4, @cantCharNivel4)  else '' end
+ case when @UsaSeparadorCta= 1 and @Nivel5<> '' then @SeparadorCta else '' end
+ case when ISNULL(@Nivel5,'')<> '' then right (replicate ( @charPredecesor, @cantCharNivel5)+ @Nivel5, @cantCharNivel5)  else '' end
	)
if @Resultado is null
	set @Resultado = ''

	

RETURN @Resultado
END


GO

Create Procedure [dbo].[cntUpdateCuentaCentroCosto] @Operacion nvarchar(1), @IDCentro int, @IDCuenta int
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT  dbo.cntCuentaCentro( IDCuenta, IDCentro ) 
	VALUES  ( @IDCuenta,@IDCentro ) 
end

if upper(@Operacion) = 'D'
begin
	DELETE  FROM dbo.cntCuentaCentro WHERE IDCentro = @IDCentro AND IDCuenta=@IDCuenta
end



GO

CREATE TABLE [dbo].[globalTipoCambio](
	[IDTipoCambio] [nvarchar](20) NOT NULL,
	[Descr] [nvarchar](50) NOT NULL,
 CONSTRAINT [pkTipoCambio] PRIMARY KEY CLUSTERED 
(
	[IDTipoCambio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[globalTipoCambioDetalle](
	[IDTipoCambio] [nvarchar](20) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Monto] [decimal](28, 8) NULL,
 CONSTRAINT [pkTipoCambioDetalle] PRIMARY KEY CLUSTERED 
(
	[IDTipoCambio] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[globalTipoCambioDetalle]  WITH CHECK ADD  CONSTRAINT [fkTipoCambioDetalle] FOREIGN KEY([IDTipoCambio])
REFERENCES [dbo].[globalTipoCambio] ([IDTipoCambio])
GO

ALTER TABLE [dbo].[globalTipoCambioDetalle] CHECK CONSTRAINT [fkTipoCambioDetalle]
GO

ALTER TABLE [dbo].[globalTipoCambioDetalle] ADD  DEFAULT ((0)) FOR [Monto]
GO


CREATE Procedure [dbo].[globalUpdateTipoCambio] @Operacion nvarchar(1), @IDTipoCambio NVARCHAR (20), @Descr AS NVARCHAR(50)
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO  dbo.globalTipoCambio( IDTipoCambio, Descr )
	VALUES ( @IDTipoCambio , @Descr )
END

if upper(@Operacion) = 'D'
begin

	if Exists ( Select IDTipoCambio  from  dbo.globalTipoCambioDetalle    Where IDTipoCambio  = @IDTipoCambio)	
	begin 
		RAISERROR ( 'El tipo de Cambio no puede eliminarser por que tiene dependencias en la Relacion TipoCambio - TipoCambioDetalle.', 16, 1) ;
		return				
	end
	
	DELETE  FROM dbo.globalTipoCambio WHERE IDTipoCambio=@IDTipoCambio
end

if upper(@Operacion) = 'U' 
begin
	Update dbo.globalTipoCambio set Descr = @Descr 
	where IDTipoCambio = @IDTipoCambio
end

GO



CREATE Procedure [dbo].[globalUpdateTipoCambioDetalle] @Operacion nvarchar(1), @IDTipoCambio NVARCHAR (20), @Fecha AS date, @Monto AS decimal(28,8)
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT INTO  dbo.globalTipoCambioDetalle( IDTipoCambio, Fecha,Monto )
	VALUES ( @IDTipoCambio , @Fecha,@Monto	)
END

if upper(@Operacion) = 'D'
begin
	DELETE  FROM dbo.globalTipoCambioDetalle WHERE IDTipoCambio=@IDTipoCambio AND Fecha=@Fecha
end

if upper(@Operacion) = 'U' 
begin
	Update dbo.globalTipoCambioDetalle set Monto = @Monto
	where IDTipoCambio = @IDTipoCambio AND Fecha=@Fecha
end


GO

INSERT INTO dbo.globalTipoCambio
        ( IDTipoCambio, Descr )
VALUES  ( N'TVEN', -- IDTipoCambio - nvarchar(20)
          N'Tipo de Cambio de Venta'  -- Descr - nvarchar(50)
          )
GO

ALTER Procedure [dbo].[cntGetProximaCuenta] @iNivel1 int  , @iNivel2 int, @iNivel3 int , @iNivel4 int  , @iNivel5 int , @NextCuenta int output
as
set nocount on
Declare @Resultado nvarchar(50)
Declare @Str nvarchar(250), @i int, @Anterior int, @Actual int, @CantItems int, @Found bit , @Siguiente INT

DECLARE @Nivel1 nvarchar(50)  , @Nivel2 nvarchar(50), @Nivel3 nvarchar(50) , @Nivel4 nvarchar(50)  , @Nivel5 nvarchar(50) 


Declare  @iCantidad int , @UsaPredecesor bit, @charPredecesor nvarchar(1), 
@cantCharNivel1 int,  @cantCharNivel2 int, @cantCharNivel3 int, @cantCharNivel4 int, @cantCharNivel5 int 



Select TOP 1 
@charPredecesor = charPredecesor, @cantCharNivel1 = cantCharNivel1, @cantCharNivel2 = cantCharNivel2,
@cantCharNivel3 = cantCharNivel3, @cantCharNivel4 = cantCharNivel4, @cantCharNivel5 = cantCharNivel5
from  dbo.cntParametros
	
	

	
SET @Nivel1 = CASE WHEN @iNivel1=-1 THEN '-1' WHEN @iNivel1=0 THEN '0' ELSE   right(replicate ( @charPredecesor, @cantCharNivel1) +  ISNULL(CAST(@iNivel1 AS NVARCHAR(50)) ,'')  , @cantCharNivel1 ) END 
SET @Nivel2= CASE WHEN @iNivel2=-1 THEN '-1' WHEN @iNivel2=0 THEN '0' ELSE right (replicate ( @charPredecesor, @cantCharNivel2)+ CAST(@iNivel2 AS NVARCHAR(50)), @cantCharNivel2) END
SET @Nivel3=  CASE WHEN @iNivel3=-1 THEN '-1' WHEN @iNivel3=0 THEN '0' ELSE right (replicate ( @charPredecesor, @cantCharNivel3)+ CAST(@iNivel3 AS NVARCHAR(50)), @cantCharNivel3) END
SET @Nivel4=  CASE WHEN @iNivel4=-1 THEN '-1' WHEN @iNivel4=0 THEN '0' ELSE right (replicate ( @charPredecesor, @cantCharNivel4)+ CAST(@iNivel4 AS NVARCHAR(50)), @cantCharNivel4) END
SET @Nivel5= CASE WHEN @iNivel5=-1 THEN '-1' WHEN @iNivel5=0 THEN '0' ELSE  right (replicate ( @charPredecesor, @cantCharNivel5)+ CAST(@iNivel5 AS NVARCHAR(50)), @cantCharNivel5) END



set @Str = case when @Nivel1 = '-1' then '' else '%' + @Nivel1 + '%' end
set @Str = @Str + case when @Nivel2 = '-1' then '' else  @Nivel2 + '%' end
set @Str = @Str + case when @Nivel3 = '-1' then '' else  @Nivel3 + '%' end
set @Str = @Str + case when @Nivel4 = '-1' then '' else  @Nivel4 + '%' end
set @Str = @Str + case when @Nivel5 = '-1' then '' else  @Nivel5 + '%' end


Create Table #Cuenta ( ID int identity(1,1), nivel1 nvarchar(50), nivel2 nvarchar(50),
nivel3 nvarchar(50),  nivel4 nvarchar(50), nivel5 nvarchar(50), Cuenta nvarchar(50))
insert #Cuenta ( nivel1 , nivel2 , nivel3 ,nivel4 , nivel5 , Cuenta )
select Nivel1, Nivel2 , Nivel3 , Nivel4, Nivel5, Cuenta 
from dbo.cntCuenta 
where @Str = '' or Cuenta like @Str 
ORDER BY CAST(Nivel1 AS INT),CAST(Nivel2 AS INT),CAST(Nivel3 AS INT),CAST(Nivel4 AS INT),CAST(Nivel5 AS INT)


set @CantItems = @@IDENTITY 

declare @First int, @Second int

set @i = 1
set @Found = 0
set @Anterior = -1
set @First = -1
while @i <= @CantItems and @Found = 0
begin
set @Anterior = @First 
Select @First = case when @nivel1 = '-1' then cast(nivel1 AS int)
				else
					case when @nivel2 = '-1' then cast(nivel2 AS int )
					else
						case when @nivel3 = '-1' then cast(nivel3 AS int )
						else
							case when @nivel4 = '-1' then cast(nivel4 AS int )
							else
								case when @nivel5 = '-1' then CAST( nivel5 AS int ) end
							end
						end
					end
				end 
			 

from #Cuenta
where ID = @i 
if @First <>  0 and @Anterior = -1	
begin
	set @Siguiente = ISNULL(@First,0) + 1
	set @Found = 1
end
else
begin

	if (@i <= @CantItems)  and (@first - @Anterior ) >1 
	begin

		set @Found = 1
		set @Siguiente = @Anterior + 1
	end
	else
	begin
		if @i = @CantItems --and (@first - @Anterior ) =1
		begin
			set @Found = 1
			set @Siguiente = @First + 1
		end
	end
end
set @i = @i + 1
end

set @NextCuenta = @Siguiente 
drop table #Cuenta
return @NextCuenta

go



CREATE  PROCEDURE cntRptGetAsiento @Asiento AS NVARCHAR(20)
AS
--SET @Asiento='CG0000000016'

SELECT IDEjercicio,Periodo,Asiento,A.Tipo,B.Descr DescrTipo,Fecha,FechaHora,Createdby,CreateDate,Mayorizado,Mayorizadoby,MayorizadoDate,Concepto,Anulado, TipoCambio,ModuloFuente,CuadreTemporal
FROM dbo.cntAsiento A
INNER JOIN dbo.cntTipoAsiento B ON a.Tipo=B.Tipo
WHERE Asiento=@Asiento



GO 

CREATE  PROCEDURE cntRptGetAsientoDetalle @Asiento AS NVARCHAR(20)
AS
--SET @Asiento='CG0000000016'

SELECT Asiento,Linea,A.IDCentro,CC.Centro,cc.Descr DescrCentro,C.IDCuenta,C.Cuenta,C.Descr DescrCuenta,Debito,Credito,Documento,A.Referencia,daterecord  FROM dbo.cntAsientoDetalle A
INNER JOIN dbo.cntCuenta C ON a.IDCuenta=c.IDCuenta
INNER JOIN dbo.cntCentroCosto CC ON A.IDCentro=cc.IDCentro
WHERE Asiento=@Asiento

GO


CREATE FUNCTION [dbo].[ConvertListoToTable](
 @String nvarchar (4000),
 @Delimiter nvarchar (10)
 )
returns @ValueTable table ([Value] nvarchar(4000))
begin
 declare @NextString nvarchar(4000)
 declare @Pos int
 declare @NextPos int
 declare @CommaCheck nvarchar(1)
 
 --Initialize
 set @NextString = ''
 set @CommaCheck = right(@String,1) 
 
 --Check for trailing Comma, if not exists, INSERT
 --if (@CommaCheck <> @Delimiter )
 set @String = @String + @Delimiter
 
 --Get position of first Comma
 set @Pos = charindex(@Delimiter,@String)
 set @NextPos = 1
 
 --Loop while there is still a comma in the String of levels
 while (@pos <>  0)  
 begin
  set @NextString = substring(@String,1,@Pos - 1)
 
  insert into @ValueTable ( [Value]) Values (@NextString)
 
  set @String = substring(@String,@pos +1,len(@String))
  
  set @NextPos = @Pos
  set @pos  = charindex(@Delimiter,@String)
 end
 
 return
end

GO


CREATE  PROCEDURE  [dbo].[cntGetAsientoByCriterio] @FechaInicial AS DATE,@FechaFinal AS DATE,@Tipo AS NVARCHAR(800),@Mayorizado AS INT,@Anulado AS INT,@ModuloFuente AS NVARCHAR(800),@CuadreTemporal AS INT
AS 
/*
SET @FechaInicial = '20170501'
SET @FechaFinal = '20170531'
SET @Tipo ='FA∞CG∞CI'
SET @Mayorizado=0
SET @Anulado=0
SET @ModuloFuente = 'CG'
SET @CuadreTemporal=0
*/

set @FechaInicial = CAST(SUBSTRING(CAST(@FechaInicial AS CHAR),1,11) + ' 00:00:00.000' AS DATETIME)
set @FechaFinal = CAST(SUBSTRING(CAST(@FechaFinal AS CHAR),1,11) + ' 23:59:59.998' AS DATETIME)


SELECT IDEjercicio, Periodo, Asiento, Tipo, Fecha, FechaHora, Createdby, CreateDate, Mayorizadoby, MayorizadoDate, 
                            Concepto, Mayorizado, Anulado, TipoCambio, ModuloFuente, CuadreTemporal 
                              FROM dbo.cntAsiento WHERE Fecha BETWEEN @FechaInicial AND @FechaFinal  AND (Tipo IN (SELECT Value FROM [dbo].[ConvertListoToTable](@Tipo,'~'))) 
							AND (Mayorizado = @Mayorizado OR @Mayorizado = -1) AND(Anulado = @Anulado OR @Anulado = -1) AND (ModuloFuente  IN (SELECT Value FROM [dbo].[ConvertListoToTable](@ModuloFuente,'~'))) 
                            AND(CuadreTemporal = @CuadreTemporal OR @CuadreTemporal = -1)


go 



CREATE Procedure [dbo].[cntUpdateParametrosContabilidad] @Operacion NVARCHAR(1),@ID INT, @UsaSeparadorCuenta BIT, @SeparadorCta nvarchar(1), @UsaPredecesor BIT,  @charPredecesor NVARCHAR(1),@CantCharNivel1 NVARCHAR(50), @CantCharNivel2 NVARCHAR(50),@CantCharNivel3 NVARCHAR(50),@CantCharNivel4 NVARCHAR(50),@CantCharNivel5 NVARCHAR(50),
@IDCtaUtilidadAcumulada INT , @IDCtaUtilidadPeriodo int, @MesInicioPeriodoFiscal bit, @MesFinalPeriodoFiscal INT,@UsaSeparadorCentro BIT,@SeparadorCentro NVARCHAR(1),@UsaPredecesorCentro BIT, @charPredecesorCentro NVARCHAR(50),@LongAsiento INT
as
set nocount on 

if upper(@Operacion) = 'I'
begin
	INSERT  dbo.cntParametros( UsaSeparadorCta ,SeparadorCta ,UsaPredecesor ,charPredecesor ,CantCharNivel1 ,CantCharNivel2 ,CantCharNivel3 ,
														CantCharNivel4 ,CantCharNivel5 ,IDCtaUtilidadPeriodo ,IDCtaUtilidadAcumulada ,MesInicioPeriodoFiscal ,MesFinalPeriodoFiscal ,
														UsaSeparadorCentro ,SeparadorCentro ,UsaPredecesorCentro ,charPredecesorCentro ,LongAsiento)
	VALUES  ( @UsaSeparadorCuenta,@SeparadorCta,@UsaPredecesor,@charPredecesor,@CantCharNivel1,@CantCharNivel2,@CantCharNivel3,@CantCharNivel4,@CantCharNivel5,
				@IDCtaUtilidadAcumulada,@IDCtaUtilidadPeriodo,@MesInicioPeriodoFiscal,@MesFinalPeriodoFiscal,@UsaSeparadorCentro,@SeparadorCentro,
				@UsaPredecesorCentro,@charPredecesorCentro,@LongAsiento)
	          
end


if upper(@Operacion) = 'U' 
begin
	UPDATE  dbo.cntParametros SET UsaSeparadorCta=@UsaSeparadorCuenta, SeparadorCta=@SeparadorCta,UsaPredecesor=@UsaPredecesor,
														charPredecesor=@charPredecesor,CantCharNivel1 =@CantCharNivel1,CantCharNivel2 =@CantCharNivel2,
														CantCharNivel3 =@CantCharNivel4,CantCharNivel4 =@CantCharNivel4,CantCharNivel5 =@CantCharNivel5,
														IDCtaUtilidadAcumulada=@IDCtaUtilidadAcumulada,IDCtaUtilidadPeriodo=@IDCtaUtilidadPeriodo,MesInicioPeriodoFiscal=@MesInicioPeriodoFiscal,
														MesFinalPeriodoFiscal =@MesFinalPeriodoFiscal,UsaSeparadorCentro=@UsaSeparadorCentro,SeparadorCentro=@SeparadorCentro,
														UsaPredecesorCentro =@UsaPredecesorCentro,charPredecesorCentro=@charPredecesorCentro,LongAsiento=@LongAsiento
	WHERE ID=@ID
end


GO





/*

Select * from dbo.cntCuenta
Declare @IDEjercicio int, @Periodo nvarchar(10), @IDCuenta int, @Centro int, @SoloMayor bit = 1

set @IDEjercicio = 2017
set @Periodo = '201701'
set @IDCuenta = 5
set @Centro = 0
set @SoloMayor = 1

exec dbo.cntGetSaldoAcumulado @IDEjercicio, @Periodo, @IDCuenta, @Centro, @SoloMayor
*/
--@FechaSaldoAnt, @SaldoAnterior SaldoAnterior, @TipoCambioSaldoAnt TipoCambioAnt, 



/*




Select * from dbo.cntCuenta order by idgrupo, idTipo, IDSubTipo, idCuentaAnterior

SELECT * FROM dbo.cntAsiento 
SELECT * FROM dbo.cntAsientoDetalle 

select * from dbo.cntEjercicio 
select * from dbo.cntperiodocontable 

*/



-- ********************************************************************************************************************* 

/*

select * into test.dbo.tmpCuenta from dbo.cntCuenta where idcuenta > 7
 INSERT dbo.cntCuenta (  IDGrupo, IDtipo, IDSubTipo, Tipo, Subtipo, Nivel1, Nivel2 ,  Nivel3, Nivel4, Nivel5, Naturaleza, Descr, 
 Complementaria, EsMayor, AceptaDatos, IDCuentaAnterior , IDCuentaMayor )
 Values( 1,1,1,'B', 'A',  '1','', '','','', 'D','ACTIVO',  1,1, 0, 1,1)
go 
  INSERT dbo.cntCuenta (  IDGrupo, IDtipo, IDSubTipo, Tipo, Subtipo, Nivel1, Nivel2 ,  Nivel3, Nivel4, Nivel5, Naturaleza, Descr, 
 Complementaria, EsMayor, AceptaDatos, IDCuentaAnterior , IDCuentaMayor )
  Values( 1,1,1,'B', 'A',  '1','7', '','','', 'D','ACTIVO FIJO', 1,1, 0, 1,1)
go
 INSERT dbo.cntCuenta (  IDGrupo, IDtipo, IDSubTipo, Tipo, Subtipo, Nivel1, Nivel2 ,  Nivel3, Nivel4, Nivel5, Naturaleza, Descr, 
 Complementaria, EsMayor, AceptaDatos, IDCuentaAnterior , IDCuentaMayor )
  Values( 1,1,1,'B', 'A',  '1','1', '2','','', 'D','ACTIVO FIJO xx', 1,1, 0, 1,1)
go

 INSERT dbo.cntCuenta (  IDGrupo, IDtipo, IDSubTipo, Tipo, Subtipo, Nivel1, Nivel2 ,  Nivel3, Nivel4, Nivel5, Naturaleza, Descr, 
 Complementaria, EsMayor, AceptaDatos, IDCuentaAnterior , IDCuentaMayor )
  Values( 1,2,1,'B', 'A',  '1','1', '3','','', 'D','ACTIVO FIJO xxxxx', 1,1, 0, 1,1)
go


*/


-- ACTUALIZA EL SALDO DE UNA CUENTA exec dbo.cntUpdateSaldoCuenta 2017, '201701', 5,0,100,0
-- drop procedure dbo.cntUpdateSaldoCuenta
CREATE  Procedure dbo.cntUpdateSaldoCuenta @IDEjercicio int, @Periodo nvarchar(10),
 @IDCuenta int, @IDCentro int, @Debito decimal(28,4), @Credito decimal(28,4)
as
set nocount on


Declare @NaturalezaSaldo nvarchar(1), @MontoSaldo decimal(28,4), @Fecha date, @IDEjercicioAnt int, @PeriodoAnt nvarchar(10)
set @Debito = ISNULL(@Debito,0)
set @Credito = ISNULL( @Credito, 0)
set @IDEjercicioAnt = @IDEjercicio
set @PeriodoAnt = @Periodo
exec dbo.cntGetPeriodoFromEjercicio @IDEjercicioAnt  output, @PeriodoAnt output, 'A'

--select @PeriodoAnt periodoant

Select @Fecha = FechaFinal 
from dbo.cntPeriodoContable 
where IDEjercicio = @IDEjercicio and Periodo = @Periodo 

SELECT @NaturalezaSaldo = NaturalezaSaldo
FROM dbo.vcntCatalogo 
Where IDCuenta = @IDCuenta

if @NaturalezaSaldo = 'D' -- Naturaleza Deudora
	set @MontoSaldo = @Debito - @Credito
else
	set @MontoSaldo = @Credito - @Debito

Create table #CtasMayor ( IDCuenta int, IDCentro int, IDEjercicio int, Periodo nvarchar(10), SaldoAnt decimal(28,4) default 0  )

Declare @Sigue bit ,@IDCuentaMayor int, @IDCuentaActual int
set @Sigue = 1
set @IDCuentaActual = @IDCuenta
-- inserto la cuenta actual para luego calcular el saldo con las de mayor
insert #CtasMayor ( IDCuenta, IDCentro , IDEjercicio , Periodo  )
values (@IDCuenta, @IDCentro , @IDEjercicio , @Periodo )

while @Sigue = 1
begin
	Select  @IDCuentaMayor = IDCuentaMayor 
	from dbo.cntCuenta (nolock)
	where IDCuenta = @IDCuentaActual 
	if @IDCuentaMayor <> 0
		begin
		insert #CtasMayor ( IDCuenta, IDCentro , IDEjercicio , Periodo  )
		values (@IDCuentaMayor, @IDCentro , @IDEjercicio , @Periodo )
		end
	Select @IDCuentaActual = IDCuenta 
	From dbo.cntCuenta 
	where IDCuenta = @IDCuentaMayor

	if @IDCuentaMayor = 0
		set @Sigue = 0
	
	
end

-- Actualizo las que estan en saldo

Update S set Saldo = isnull(Saldo ,0 ) + @MontoSaldo ,S.Debito = isnull(S.Debito,0) +  @Debito,S.Credito=isnull(S.Credito,0) + @Credito
from dbo.cntSaldo (nolock) S inner join #CtasMayor M
on S.IDCuenta = M.IDCuenta and S.IDCentro = M.IDCentro and s.IDEjercicio = M.IDEjercicio and s.Periodo = M.Periodo 

Select @idejercicio IDEjercicio ,@Periodo  Periodo, IDCuenta, IDCentro, Saldo SaldoAnterior
into #SaldoAnterior 
from dbo.cntSaldo (nolock) S
where IDEjercicio = @IDEjercicioAnt and Periodo = @PeriodoAnt 
and IDCentro = @IDCentro and  IDCuenta in (Select IDCuenta from #CtasMayor )


-- para insertar los que no existen en saldos -- SELECT * FROM #CtasMayor 
-- estos son los que corresponden al periodo
INSERT dbo.cntSaldo(IDEjercicio, Periodo , IDCentro , IDCuenta ,  Fecha, Saldo,Debito,Credito )
SELECT A.IDEjercicio , A.Periodo , A.IDCentro , A.IDCuenta , A.Fecha, A.Saldo + ISNULL(B.SaldoAnterior,0) Saldo,@Debito,@Credito
FROM (
Select   M.IDEjercicio IDEjercicio, M.Periodo Periodo , M.IDCuenta, M.IDCentro  IDCentro, @Fecha Fecha,
@MontoSaldo Saldo
from dbo.cntSaldo (nolock) S right join #CtasMayor M
on S.IDCuenta = M.IDCuenta and S.IDCentro = M.IDCentro and S.IDEjercicio = M.IDEjercicio and S.Periodo = M.Periodo 
where S.IDCuenta is null and S.IDCENTRO IS NULL  AND S.IDEjercicio is null and S.Periodo is null
) A LEFT JOIN #SaldoAnterior B
ON A.IDCentro = B.IDCENTRO AND A.IDCuenta = B.IDCuenta and A.IDEjercicio = B.IDEjercicio and A.Periodo= B.Periodo


drop table #CtasMayor
drop table #SaldoAnterior


go


--drop procedure dbo.cntMayorizarAsiento
Create Procedure dbo.cntMayorizarAsiento  @IDEjercicio int, @Periodo nvarchar(10), @Asiento nvarchar(20), @Usuario nvarchar(20), @Exito bit output 
as
set nocount on
declare @Count int, @i int
set @Exito = 0
Select @Count = COUNT(*) 
from dbo.cntAsientoDetalle D inner join dbo.cntAsiento A
on D.Asiento = A.Asiento 
where D.Asiento = @Asiento and A.Mayorizado = 0 and A.Anulado  =0 and A.Cuadretemporal =0
if @Count = 0
begin
	RAISERROR ( 'Ese asiento contable no se puede Mayorizar porque puede estar ya Marorizado, Anulado o tiene Cuadre Temporal, por favor revise', 16, 1) ;
	return
end

DECLARE @IDCentro int, @IDCuenta int, @Debito decimal(28,4) ,@Credito decimal(28,4)
Create table #Detalle (ID int identity(1,1) not null,  Asiento nvarchar(20), IDCentro int, IDCuenta int, Debito decimal(28,4) default 0,
Credito decimal(28,4) default 0 )
alter table #Detalle add constraint pkdetalle primary key (ID)
INSERT #Detalle (Asiento, IDCentro, IDCuenta, Debito , Credito )
Select D.Asiento, IDCentro, IDCuenta, Debito , Credito 
from dbo.cntAsientoDetalle D inner join dbo.cntAsiento A
on D.Asiento = A.Asiento 
where D.Asiento = @Asiento and A.Mayorizado = 0 and A.anulado =0 and A.Cuadretemporal =0
ORDER BY Linea ASC

BEGIN TRANSACTION 
BEGIN TRY

set @i = 1
While  @i <= @Count 
begin
	SELECT @IDCentro = IDCentro, @IDCuenta = IDCuenta, @Debito = DEBITO , @Credito = Credito 
	FROM #Detalle 
	WHERE ID = @i  
	exec dbo.cntUpdateSaldoCuenta @IDEjercicio , @Periodo , @IDCuenta , @IDCentro , @Debito , @Credito 	
	--select'vars ejercicio, periodo, cuenta, centro, debito, credito' descr, @IDEjercicio , @Periodo , @IDCuenta , @IDCentro , @Debito , @Credito 	
	set @i = @i + 1
end
-- actualizar la cabecera 
Update dbo.cntAsiento  set Mayorizado = 1, Mayorizadoby = @Usuario, MayorizadoDate = GETDATE()
Where Asiento = @Asiento 
set @Exito = 1
drop table #Detalle

END TRY
BEGIN CATCH
		IF @@TRANCOUNT > 0  
		begin
			ROLLBACK TRANSACTION;
			IF OBJECT_ID('tempdb..#Detalle') IS NOT NULL
				DROP TABLE #Detalle
			set @Exito = 0
		end
END CATCH
		IF @@TRANCOUNT > 0  
		begin
			COMMIT TRANSACTION; 	
			set @Exito = 1
		end
go


Create Procedure dbo.cntRevertirAsiento  @IDEjercicio int, @Periodo nvarchar(10), @Asiento nvarchar(20),@AsientoReversion NVARCHAR(20) OUTPUT, @Usuario nvarchar(20), @Exito bit output 
as
set nocount on
declare @Count int, @i int
set @Exito = 0
Select @Count = COUNT(*) 
from dbo.cntAsientoDetalle D inner join dbo.cntAsiento A
on D.Asiento = A.Asiento 
where D.Asiento = @Asiento and A.Mayorizado = 1 and A.Anulado  =0 and A.Cuadretemporal =0
if @Count = 0
begin
	RAISERROR ( 'Ese asiento contable no se puede revertir porque no esta Mayorizado,  por favor revise', 16, 1) ;
	return
end

DECLARE @IDCentro int, @IDCuenta int, @Debito decimal(28,4) ,@Credito decimal(28,4)
Create table #Detalle (ID int identity(1,1) not null, Linea INT, Asiento nvarchar(20), IDCentro int, IDCuenta int, Debito decimal(28,4) default 0,
Credito decimal(28,4) default 0,Referencia NVARCHAR(200) )
alter table #Detalle add constraint pkdetalle primary key (ID)

INSERT #Detalle (Asiento,Linea, IDCentro, IDCuenta, Debito , Credito, Referencia )
Select D.Asiento, Linea,IDCentro, IDCuenta, Credito ,Debito, 'Anulación del documento ' + @Asiento
from dbo.cntAsientoDetalle D inner join dbo.cntAsiento A
on D.Asiento = A.Asiento 
where D.Asiento = @Asiento and A.Mayorizado = 0 and A.anulado =0 and A.Cuadretemporal =0
ORDER BY Linea ASC


BEGIN TRANSACTION 
BEGIN TRY

set nocount on 
declare @LongAsiento INT , @Consecutivo int 
DECLARE @Tipo AS NVARCHAR(2)


select @LongAsiento = LongAsiento from dbo.cntParametros 
SELECT @Tipo = Tipo FROM dbo.cntAsiento WHERE Asiento=@Asiento

--Ingresar el asiento de diario
SELECT @AsientoReversion = (tipo + RIGHT( replicate('0', @LongAsiento ) + cast (Consecutivo + 1 as nvarchar(20)), @LongAsiento ) ),
 				@Consecutivo = Consecutivo + 1     
FROM dbo.cntTipoAsiento (UPDLOCK)                             
WHERE TIPO = @Tipo


if exists (Select Asiento From dbo.cntAsiento (NOLOCK)  where Asiento = @Asiento )
begin
	RAISERROR ( 'Ya Existe ese asiento contable, no se puede crear', 16, 1) ;		
end	
Update dbo.cntTipoAsiento set UltimoAsiento = @Asiento , Consecutivo = @Consecutivo 		 			
where Tipo = @Tipo 

DECLARE @TipoCambio AS DECIMAL(28,2)
SELECT @TipoCambio = Monto  FROM dbo.globalTipoCambioDetalle WHERE IDTipoCambio='TVEN' AND Fecha = CAST(GETDATE() AS DATE)


--Insertar el documento
INSERT INTO dbo.cntAsiento        ( IDEjercicio ,          Periodo ,          Asiento ,          Tipo ,          Fecha ,          FechaHora ,          Createdby ,          CreateDate ,
          Mayorizadoby ,          MayorizadoDate ,          Concepto ,          Mayorizado ,          Anulado ,          TipoCambio ,          ModuloFuente ,          CuadreTemporal
        )
VALUES  ( @IdEjercicio , -- IDEjercicio - int
          @Periodo , -- Periodo - nvarchar(10)
           @AsientoReversion, -- Asiento - nvarchar(20)
          @Tipo , -- Tipo - nvarchar(2)
          GETDATE() , -- Fecha - date
          GETDATE(), -- FechaHora - datetime
          @Usuario , -- Createdby - nvarchar(20)
          GETDATE() , -- CreateDate - datetime
          NULL , -- Mayorizadoby - nvarchar(20)
		  NULL , -- MayorizadoDate - datetime
          N'Reversión del documento ' + @Asiento , -- Concepto - nvarchar(255)
          0 , -- Mayorizado - bit
          0 , -- Anulado - bit
          @TipoCambio , -- TipoCambio - decimal
          N'CG' , -- ModuloFuente - nvarchar(2)
          0  -- CuadreTemporal - bit
        )

INSERT INTO dbo.cntAsientoDetalle
        ( Asiento ,
          Linea ,
          IDCentro ,
          IDCuenta ,
          Referencia ,
          Debito ,
          Credito ,
          Documento ,
          daterecord
        )
SELECT @AsientoReversion,Linea, IDCentro, IDCuenta,Referencia, Debito , Credito, '',GETDATE()   FROM #Detalle 


set @i = 1
While  @i <= @Count 
begin
	SELECT @IDCentro = IDCentro, @IDCuenta = IDCuenta, @Debito = DEBITO , @Credito = Credito 
	FROM #Detalle 
	WHERE ID = @i  
	exec dbo.cntUpdateSaldoCuenta @IDEjercicio , @Periodo , @IDCuenta , @IDCentro , @Debito , @Credito 	
	--select'vars ejercicio, periodo, cuenta, centro, debito, credito' descr, @IDEjercicio , @Periodo , @IDCuenta , @IDCentro , @Debito , @Credito 	
	set @i = @i + 1
end
-- actualizar la cabecera 
Update dbo.cntAsiento  set Mayorizado = 1, Mayorizadoby = @Usuario, MayorizadoDate = GETDATE()
Where Asiento = @Asiento 
set @Exito = 1
drop table #Detalle

END TRY
BEGIN CATCH
		IF @@TRANCOUNT > 0  
		begin
			ROLLBACK TRANSACTION;
			IF OBJECT_ID('tempdb..#Detalle') IS NOT NULL
				DROP TABLE #Detalle
			set @Exito = 0
		end
END CATCH
		IF @@TRANCOUNT > 0  
		begin
			COMMIT TRANSACTION; 	
			set @Exito = 1
		end
go


CREATE PROCEDURE  dbo.cntCuadreTemporal(@Asiento AS NVARCHAR(20))
as
set nocount ON
DECLARE @Debito AS DECIMAL(28,2),@Credito AS DECIMAL(28,2)
DECLARE @Diferencia AS DECIMAL(28,2)
SELECT @Debito =SUM(Debito), @Credito= SUM(Credito)  FROM dbo.cntAsientoDetalle WHERE Asiento=@Asiento

SET @Diferencia =(@Debito-@Credito)
IF (@Diferencia >0 )
BEGIN
	IF (@Debito<@Credito)
		BEGIN
			SET @Debito = @Debito + @Diferencia
			UPDATE dbo.cntAsientoDetalle SET  Debito = @Debito WHERE Asiento =@Asiento AND Linea= 	(SELECT TOP 1 Linea FROM dbo.cntAsientoDetalle WHERE Asiento=@Asiento
			ORDER BY Linea DESC)
		END
	ELSE 
		BEGIN
			SET @Credito = @Credito + @Diferencia
			UPDATE dbo.cntAsientoDetalle SET  Credito = @Credito WHERE Asiento =@Asiento AND Linea= 	(SELECT TOP 1 Linea FROM dbo.cntAsientoDetalle WHERE Asiento=@Asiento
			ORDER BY Linea DESC)
		END
	UPDATE dbo.cntAsiento SET  CuadreTemporal=1 WHERE Asiento=@Asiento
END 	
	

GO


CREATE PROCEDURE	dbo.cntValidaFechaInPeriodoContables  @Fecha AS DATE
AS 
SET @Fecha =  DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@Fecha)+1,0))
DECLARE @PeriodoTrabajo AS BIT, @Cerrado AS BIT

SELECT @PeriodoTrabajo=PeriodoTrabajo,@Cerrado = Cerrado
  FROM dbo.cntPeriodoContable WHERE FechaFinal=@Fecha


IF (@Cerrado=1)
BEGIN
	RAISERROR('• La fecha seleccionada corresponde a un periodo de trabajo, ya CERRADO.',16,1)
END	

IF (@PeriodoTrabajo=0)
BEGIN
	RAISERROR('• La fecha seleccionada NO corresponde a un periodo de trabajo ACTIVO.',16,1)
END


go


--Cerrar Periodo Contable 
CREATE PROCEDURE dbo.cntCierraPeriodoContable (@IDEjercicio AS INT,@Periodo  AS NVARCHAR(8))
AS 
--Validar si existe un periodo anterior abierto
--DECLARE @IDEjercicio AS INT
--DECLARE @Periodo  AS NVARCHAR(8)

--SET @IDEjercicio=2017
--SET @Periodo = '201706'


DECLARE @IDEjercicioAnt AS INT
DECLARE @PeriodoAnt  AS NVARCHAR(8)
SET @IDEjercicioAnt=@IDEjercicio
SET @PeriodoAnt = @Periodo
exec dbo.cntGetPeriodoFromEjercicio @IDEjercicioAnt  output, @PeriodoAnt output, 'A'

DECLARE @Cerrado  AS BIT
SELECT @Cerrado = Cerrado  FROM dbo.cntPeriodoContable WHERE IDEjercicio=@IDEjercicioAnt AND Periodo=@PeriodoAnt

IF (@Cerrado=0)
BEGIN
		RAISERROR ( 'Existe un periodo anterior que no esta cerrado por favor verifique..', 16, 1) ;
		RETURN 
END


--Validar que no exitan asientos de diario del periodo a cerrar sin mayorizar
IF EXISTS( SELECT *  FROM dbo.cntAsiento WHERE IDEjercicio=@IDEjercicio AND Periodo=@Periodo AND Mayorizado=0 )
BEGIN
	RAISERROR ( 'Existen asientos de diarios que aun no han sido mayorizados, por favor verifique...', 16, 1) ;
	RETURN
END


--Preguntar por mas validaciones

UPDATE dbo.cntPeriodoContable SET Cerrado=1 WHERE IDEjercicio=@IDEjercicio AND Periodo=@Periodo


GO




CREATE PROCEDURE	[dbo].[cntGetPeriodoContableByFecha]  @Fecha AS DATE
AS 
DECLARE @TipoCambio AS DECIMAL(28,4)

SELECT @TipoCambio = Monto  FROM dbo.globalTipoCambioDetalle
WHERE IDTipoCambio = (SELECT TOP 1 IDTipoCambio  FROM dbo.globalCompania) AND Fecha=@Fecha

SET @Fecha =  DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@Fecha)+1,0))
DECLARE @PeriodoTrabajo AS BIT, @Cerrado AS BIT

SELECT  IDEjercicio ,
        Periodo ,
        FechaFinal ,
        Descr ,
        FinPeriodoFiscal ,
        Cerrado ,
        AjustesCierreFiscal ,
        Activo ,
        PeriodoTrabajo,
       @TipoCambio TipoCambio 
  FROM dbo.cntPeriodoContable WHERE FechaFinal=@Fecha
  
  
  GO
  
  
  
  
CREATE PROCEDURE [dbo].[cntGetNextConsecutivoCentroCostoFinal] (@iNivel1 AS INT,@iNivel2 AS INT,@iNivel3 AS INT,@NextCentro int output)
AS
set nocount on
	
	Declare @Str nvarchar(250), @i int, @Anterior int, @Actual int, @CantItems int, @Found bit , @Siguiente INT
	DECLARE @Nivel1 nvarchar(50)  , @Nivel2 nvarchar(50), @Nivel3 nvarchar(50)
	Declare   @charPredecesor nvarchar(1), 
	@cantCharNivel1 int,  @cantCharNivel2 int, @cantCharNivel3 int

	SET @cantCharNivel1=2
	SET @cantCharNivel2=2
	set @cantCharNivel3=2
	SET @charPredecesor='0'

	SET @Nivel1 = CASE WHEN @iNivel1=-1 THEN '-1' WHEN @iNivel1=0 THEN '0' ELSE   right(replicate ( @charPredecesor, @cantCharNivel1) +  ISNULL(CAST(@iNivel1 AS NVARCHAR(50)) ,'')  , @cantCharNivel1 ) END 
	SET @Nivel2= CASE WHEN @iNivel2=-1 THEN '-1' WHEN @iNivel2=0 THEN '0' ELSE right (replicate ( @charPredecesor, @cantCharNivel2)+ CAST(@iNivel2 AS NVARCHAR(50)), @cantCharNivel2) END
	SET @Nivel3=  CASE WHEN @iNivel3=-1 THEN '-1' WHEN @iNivel3=0 THEN '0' ELSE right (replicate ( @charPredecesor, @cantCharNivel3)+ CAST(@iNivel3 AS NVARCHAR(50)), @cantCharNivel3) END

	set @Str = case when @Nivel1 = '-1' then '' else '%' + @Nivel1 + '%' end
	set @Str = @Str + case when @Nivel2 = '-1' then '' else  @Nivel2 + '%' end
	set @Str = @Str + case when @Nivel3 = '-1' then '' else  @Nivel3 + '%' end

	Create Table #Centro ( ID int identity(1,1), nivel1 nvarchar(50), nivel2 nvarchar(50),
	nivel3 nvarchar(50),  Centro nvarchar(50))
	

	INSERT  #Centro
			(  nivel1, nivel2, nivel3, Centro )
	select Nivel1, Nivel2 , Nivel3 ,Centro
	from dbo.cntCentroCosto 
	where @Str = '' or Centro like @Str 
	ORDER BY CAST(Nivel1 AS INT),CAST(Nivel2 AS INT),CAST(Nivel3 AS INT)
	
	set @CantItems = @@IDENTITY 

	declare @First int, @Second int
	
	set @i = 1
	set @Found = 0
	set @Anterior = -1
	set @First = -1
	while @i <= @CantItems and @Found = 0
	begin
	set @Anterior = @First 
	Select @First = case when @nivel1 = '-1' then cast(nivel1 AS int)
					else
						case when @nivel2 = '-1' then cast(nivel2 AS int )
						else
							case when @nivel3 = '-1' then cast(nivel3 AS int ) end
							end
						end
	from #Centro
	where ID = @i 
	
	
	if @First <>  0 and @Anterior = -1	
	begin
		set @Siguiente = ISNULL(@First,0) + 1
		set @Found = 1
	end
	else
	begin

		if (@i <= @CantItems)  and (@first - @Anterior ) >1 
		begin
			set @Found = 1
			set @Siguiente = @Anterior + 1
		end
		else
		begin
			if @i = @CantItems --and (@first - @Anterior ) =1
			begin
				set @Found = 1
				set @Siguiente = @First + 1
			end
		end
	end
	set @i = @i + 1
	END

	set @NextCentro = @Siguiente 
	drop table #Centro
	return @NextCentro


  GO
  
  
  CREATE  function dbo.cntExisteCuentaPrimerNivel(@Nivel AS INT)
RETURNS bit
BEGIN
	DECLARE @result as bit
	IF exists(SELECT *  FROM dbo.cntCuenta
	WHERE Nivel1=@Nivel AND Nivel2  + Nivel3  + Nivel4 + Nivel5='0000') 
		SET @result = 1
	ELSE 
		SET @result = 0
	return (@result)
END

GO


CREATE  PROCEDURE  dbo.cntConsultaSaldosByCentroCuenta (@IdCentroCosto int , @IdCuentaContable AS INT,@FechaInicial AS DATE,@FechaFinal AS DATE)
AS 
--DECLARE  @IdCentroCosto int , @IdCuentaContable AS INT,@FechaInicial AS DATE,@FechaFinal AS DATE

--SET @IdCentroCosto=0
--SET @IdCuentaContable=-1
--SET @FechaInicial  = '20170415'
--SET @FechaFinal='20170825'

set @FechaInicial = CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(@FechaInicial)-1),@FechaInicial),101) 
set @FechaFinal = CONVERT(VARCHAR(25),DATEADD(dd,-(DAY(DATEADD(mm,1,@FechaFinal))),DATEADD(mm,1,@FechaFinal)),101)

SELECT C.Cuenta,C.Descr DescrCuenta,CC.Centro,CC.Descr DescrCentroCosto,A.Fecha,Saldo,debito,Credito  FROM dbo.cntSaldo A
INNER JOIN dbo.cntCuenta C ON A.IDCuenta=C.IDCuenta
INNER JOIN dbo.cntCentroCosto CC ON A.IDCentro=CC.IDCentro
WHERE (A.IDCuenta=@IdCuentaContable OR @IdCuentaContable=-1)  AND (A.IDCentro=@IdCentroCosto OR @IdCentroCosto=-1)
AND Fecha BETWEEN @FechaInicial AND @FechaFinal