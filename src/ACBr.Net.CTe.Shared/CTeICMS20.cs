// ***********************************************************************
// Assembly         : ACBr.Net.CTe
// Author           : RFTD
// Created          : 10-15-2016
//
// Last Modified By : RFTD
// Last Modified On : 10-15-2016
// ***********************************************************************
// <copyright file="CTeICMS20.cs" company="ACBr.Net">
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
// ***********************************************************************

using System.ComponentModel;
using ACBr.Net.Core.Generics;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Common;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.CTe
{
	public sealed class CTeICMS20 : GenericClone<CTeICMS20>, ICTeICMS, INotifyPropertyChanged
	{
		#region Events

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion Events

		#region Constructors

		public CTeICMS20()
		{
			CST = DFeICMSCst.Cst20;
		}

		#endregion Constructors

		#region Propriedades

		[DFeElement(TipoCampo.Enum, "CST", Id = "#222", Min = 2, Max = 2, Ocorrencia = Ocorrencia.Obrigatoria)]
		public DFeICMSCst CST { get; set; }

		[DFeElement(TipoCampo.De2, "pRedBC", Id = "#223", Min = 1, Max = 5, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal PRedBC { get; set; }

		[DFeElement(TipoCampo.De2, "vBC", Id = "#224", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VBC { get; set; }

		[DFeElement(TipoCampo.De2, "pICMS", Id = "#225", Min = 1, Max = 5, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal PICMS { get; set; }

		[DFeElement(TipoCampo.De2, "vICMS", Id = "#226", Min = 1, Max = 15, Ocorrencia = Ocorrencia.Obrigatoria)]
		public decimal VICMS { get; set; }

		#endregion Propriedades
	}
}