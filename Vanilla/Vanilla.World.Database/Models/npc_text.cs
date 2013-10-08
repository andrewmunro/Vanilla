using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("npc_text", Schema="mangos")]

    public partial class npc_text
    {
 
        [Column("ID")] 
		        public int ID { get; set; }
 
        [Column("text0_0")] 
		        public string text0_0 { get; set; }
 
        [Column("text0_1")] 
		        public string text0_1 { get; set; }
 
        [Column("lang0")] 
		        public byte lang0 { get; set; }
 
        [Column("prob0")] 
		        public float prob0 { get; set; }
 
        [Column("em0_0")] 
		        public int em0_0 { get; set; }
 
        [Column("em0_1")] 
		        public int em0_1 { get; set; }
 
        [Column("em0_2")] 
		        public int em0_2 { get; set; }
 
        [Column("em0_3")] 
		        public int em0_3 { get; set; }
 
        [Column("em0_4")] 
		        public int em0_4 { get; set; }
 
        [Column("em0_5")] 
		        public int em0_5 { get; set; }
 
        [Column("text1_0")] 
		        public string text1_0 { get; set; }
 
        [Column("text1_1")] 
		        public string text1_1 { get; set; }
 
        [Column("lang1")] 
		        public byte lang1 { get; set; }
 
        [Column("prob1")] 
		        public float prob1 { get; set; }
 
        [Column("em1_0")] 
		        public int em1_0 { get; set; }
 
        [Column("em1_1")] 
		        public int em1_1 { get; set; }
 
        [Column("em1_2")] 
		        public int em1_2 { get; set; }
 
        [Column("em1_3")] 
		        public int em1_3 { get; set; }
 
        [Column("em1_4")] 
		        public int em1_4 { get; set; }
 
        [Column("em1_5")] 
		        public int em1_5 { get; set; }
 
        [Column("text2_0")] 
		        public string text2_0 { get; set; }
 
        [Column("text2_1")] 
		        public string text2_1 { get; set; }
 
        [Column("lang2")] 
		        public byte lang2 { get; set; }
 
        [Column("prob2")] 
		        public float prob2 { get; set; }
 
        [Column("em2_0")] 
		        public int em2_0 { get; set; }
 
        [Column("em2_1")] 
		        public int em2_1 { get; set; }
 
        [Column("em2_2")] 
		        public int em2_2 { get; set; }
 
        [Column("em2_3")] 
		        public int em2_3 { get; set; }
 
        [Column("em2_4")] 
		        public int em2_4 { get; set; }
 
        [Column("em2_5")] 
		        public int em2_5 { get; set; }
 
        [Column("text3_0")] 
		        public string text3_0 { get; set; }
 
        [Column("text3_1")] 
		        public string text3_1 { get; set; }
 
        [Column("lang3")] 
		        public byte lang3 { get; set; }
 
        [Column("prob3")] 
		        public float prob3 { get; set; }
 
        [Column("em3_0")] 
		        public int em3_0 { get; set; }
 
        [Column("em3_1")] 
		        public int em3_1 { get; set; }
 
        [Column("em3_2")] 
		        public int em3_2 { get; set; }
 
        [Column("em3_3")] 
		        public int em3_3 { get; set; }
 
        [Column("em3_4")] 
		        public int em3_4 { get; set; }
 
        [Column("em3_5")] 
		        public int em3_5 { get; set; }
 
        [Column("text4_0")] 
		        public string text4_0 { get; set; }
 
        [Column("text4_1")] 
		        public string text4_1 { get; set; }
 
        [Column("lang4")] 
		        public byte lang4 { get; set; }
 
        [Column("prob4")] 
		        public float prob4 { get; set; }
 
        [Column("em4_0")] 
		        public int em4_0 { get; set; }
 
        [Column("em4_1")] 
		        public int em4_1 { get; set; }
 
        [Column("em4_2")] 
		        public int em4_2 { get; set; }
 
        [Column("em4_3")] 
		        public int em4_3 { get; set; }
 
        [Column("em4_4")] 
		        public int em4_4 { get; set; }
 
        [Column("em4_5")] 
		        public int em4_5 { get; set; }
 
        [Column("text5_0")] 
		        public string text5_0 { get; set; }
 
        [Column("text5_1")] 
		        public string text5_1 { get; set; }
 
        [Column("lang5")] 
		        public byte lang5 { get; set; }
 
        [Column("prob5")] 
		        public float prob5 { get; set; }
 
        [Column("em5_0")] 
		        public int em5_0 { get; set; }
 
        [Column("em5_1")] 
		        public int em5_1 { get; set; }
 
        [Column("em5_2")] 
		        public int em5_2 { get; set; }
 
        [Column("em5_3")] 
		        public int em5_3 { get; set; }
 
        [Column("em5_4")] 
		        public int em5_4 { get; set; }
 
        [Column("em5_5")] 
		        public int em5_5 { get; set; }
 
        [Column("text6_0")] 
		        public string text6_0 { get; set; }
 
        [Column("text6_1")] 
		        public string text6_1 { get; set; }
 
        [Column("lang6")] 
		        public byte lang6 { get; set; }
 
        [Column("prob6")] 
		        public float prob6 { get; set; }
 
        [Column("em6_0")] 
		        public int em6_0 { get; set; }
 
        [Column("em6_1")] 
		        public int em6_1 { get; set; }
 
        [Column("em6_2")] 
		        public int em6_2 { get; set; }
 
        [Column("em6_3")] 
		        public int em6_3 { get; set; }
 
        [Column("em6_4")] 
		        public int em6_4 { get; set; }
 
        [Column("em6_5")] 
		        public int em6_5 { get; set; }
 
        [Column("text7_0")] 
		        public string text7_0 { get; set; }
 
        [Column("text7_1")] 
		        public string text7_1 { get; set; }
 
        [Column("lang7")] 
		        public byte lang7 { get; set; }
 
        [Column("prob7")] 
		        public float prob7 { get; set; }
 
        [Column("em7_0")] 
		        public int em7_0 { get; set; }
 
        [Column("em7_1")] 
		        public int em7_1 { get; set; }
 
        [Column("em7_2")] 
		        public int em7_2 { get; set; }
 
        [Column("em7_3")] 
		        public int em7_3 { get; set; }
 
        [Column("em7_4")] 
		        public int em7_4 { get; set; }
 
        [Column("em7_5")] 
		        public int em7_5 { get; set; }
    }
}
