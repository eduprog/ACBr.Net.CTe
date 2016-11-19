﻿// ***********************************************************************
// Assembly         : ACBr.Net.CTe
// Author           : RFTD
// Created          : 11-10-2016
//
// Last Modified By : RFTD
// Last Modified On : 11-10-2016
// ***********************************************************************
// <copyright file="StatusServicoResult.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// *************************************************************

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Common;
using ACBr.Net.DFe.Core.Serializer;
using PropertyChanged;
using System;

namespace ACBr.Net.CTe.Services.StatusServico
{
	[ImplementPropertyChanged]
	[DFeRoot("retConsStatServCte", Namespace = "http://www.portalfiscal.inf.br/cte")]
	public sealed class StatusServicoResult : DFeDocument<StatusServicoResult>
	{
		[DFeElement(TipoCampo.Enum, "tpAmb", Min = 1, Max = 1, Ocorrencia = Ocorrencia.Obrigatoria)]
		public DFeTipoAmbiente TipoAmbiente { get; set; }

		[DFeElement(TipoCampo.Str, "verAplic", Min = 1, Max = 255, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string VersaoAplicacao { get; set; }

		[DFeElement(TipoCampo.Int, "cStat", Min = 1, Max = 3, Ocorrencia = Ocorrencia.Obrigatoria)]
		public int CStat { get; set; }

		[DFeElement(TipoCampo.Str, "xMotivo", Min = 1, Max = 255, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string Motivo { get; set; }

		[DFeElement(TipoCampo.Enum, "cUF", Min = 1, Max = 2, Ocorrencia = Ocorrencia.Obrigatoria)]
		public DFeCodUF UF { get; set; }

		[DFeElement(TipoCampo.DatHor, "dhRecbto", Min = 19, Max = 19, Ocorrencia = Ocorrencia.Obrigatoria)]
		public DateTime DhRecbto { get; set; }

		[DFeElement(TipoCampo.Str, "tMed", Min = 1, Max = 255, Ocorrencia = Ocorrencia.Obrigatoria)]
		public string TMed { get; set; }
	}
}