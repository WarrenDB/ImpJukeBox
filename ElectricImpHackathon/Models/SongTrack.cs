using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls.Expressions;

namespace ElectricImpHackathon.Models
{
    public class SongTrack
    {
        public int ID { get; set; }
        public string SongName { get; set; }
        public string Data { get; set; }
        //public SongSet Set { get; set; }
    }

    public class SongSet
    {
        public int ID { get; set; }
        public string SetID { get; set; }

        public virtual ICollection<SongTrack> Tracks { get; set; }
    }
}