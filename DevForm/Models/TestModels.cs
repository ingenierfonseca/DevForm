using DevExpress.DataAccess.ObjectBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevForm.Models
{
    public class TestModels
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
    }

    [HighlightedClass]
    public class Fishes : List<TestModels>
    {
        [HighlightedMember]
        public Fishes()
        {

        }
    }
}