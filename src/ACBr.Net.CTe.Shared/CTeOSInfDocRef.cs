﻿// ***********************************************************************
// Assembly         : ACBr.Net.CTe
// Author           : marcosgerene
// Created          : 01-09-2019
//
// Last Modified By : marcosgerene
// Last Modified On : 01-09-2019
// ***********************************************************************
// <copyright file="CTeIde.cs" company="ACBr.Net">
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

using System;
using System.ComponentModel;
using ACBr.Net.Core.Extensions;
using ACBr.Net.Core.Generics;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.CTe
{
    public sealed class CTeOSInfDocRef : GenericClone<CTeOSInfDocRef>, INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Propriedades

        [DFeElement(TipoCampo.Str, "nDoc", Id = "#137", Min = 1, Max = 20, Ocorrencia = Ocorrencia.Obrigatoria)]
        public string NDoc { get; set; }

        [DFeElement(TipoCampo.Str, "serie", Id = "#138", Min = 1, Max = 3, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Serie { get; set; }

        [DFeElement(TipoCampo.Str, "subserie", Id = "#139", Min = 1, Max = 3, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string SubSerie { get; set; }

        [DFeElement(TipoCampo.Dat, "dEmi", Id = "#140", Min = 10, Max = 10, Ocorrencia = Ocorrencia.Obrigatoria)]
        public DateTime DEmi { get; set; }

        [DFeElement(TipoCampo.De2, "vDoc", Id = "#141", Min = 1, Max = 13, Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public decimal? VDoc { get; set; }

        #endregion Propriedades

        #region Methods

        private bool ShouldSerializeSerie()
        {
            return !Serie.IsEmpty();
        }

        private bool ShouldSerializeSubSerie()
        {
            return !SubSerie.IsEmpty();
        }

        private bool ShouldSerializeVDoc()
        {
            return VDoc.HasValue;
        }
        #endregion Methods

    }
}
