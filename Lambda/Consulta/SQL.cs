using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Consulta
{
    public class SQL
    {

        string saaxes = @"
CREATE TABLE [dbo].[SAAXES](
	[CodProd] [varchar](25) NOT NULL,
	[Descrip] [varchar](40) NULL,
	[Descrip2] [varchar](40) NULL,
	[Descrip3] [varchar](40) NULL,
	[Refere] [varchar](15) NULL,
	[CodInst] [int] NULL,
	[Unidad] [varchar](3) NULL,
	[UndEmpaq] [varchar](3) NULL,
	[CantEmpaq] [int] NULL,
	[EsEmpaque] [int] NULL,
	[DEsLote] [int] NULL,
	[PrecioI1] [decimal](28, 4) NULL,
	[PrecioI2] [decimal](28, 4) NULL,
	[PrecioI3] [decimal](28, 4) NULL,
	[PrecioIU1] [decimal](28, 4) NULL,
	[PrecioIU2] [decimal](28, 4) NULL,
	[PrecioIU3] [decimal](28, 4) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodProd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]";

        string saaxes2 = @"
CREATE TABLE [dbo].[SAAXES2](
	[NUMEROD] [varchar](25) NOT NULL,
	[CODITEM] [varchar](25) NOT NULL,
	[NROLOTE] [varchar](25) NULL,
	[CANTIDAD] [int] NULL,
	[ESUNID] [int] NULL,
	[COSTO] [decimal](28, 4) NULL,
	[PRECIO] [decimal](28, 4) NULL,
 CONSTRAINT [SAAXES2_IXO] PRIMARY KEY CLUSTERED 
(
	[NUMEROD] ASC,
	[CODITEM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

";



    }
}
