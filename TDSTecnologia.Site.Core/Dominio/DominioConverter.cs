using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDSTecnologia.Site.Core.Dominio
{
    public class DominioConverter
    {
        public static ValueConverter<DomTurno, string> ConverterDomTurno()
        {
            ValueConverter<DomTurno, string> converter = new ValueConverter<DomTurno, string>(
            v => v.ToString(),
            v => (DomTurno)Enum.Parse(typeof(DomTurno), v));
            return converter;
        }

    }
    
}
