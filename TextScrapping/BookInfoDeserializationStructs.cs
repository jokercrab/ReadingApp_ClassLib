using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataModels
{

 
    public struct Author
    {
        public string name { get; set; }
        public string slug { get; set; }
    }

    public struct Category
    {
        public string name { get; set; }
        public string slug { get; set; }
    }

    public struct Data
    {
        public string slug { get; set; }
        public Author author { get; set; }
        public List<Category> category { get; set; }
        public string views { get; set; }
        public List<Tag> tag { get; set; }
        public int chapters { get; set; }
        public int review_count { get; set; }
        public string image { get; set; }
        public string first_chapter { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string name { get; set; }
   
        public string description { get; set; }
        public int numOfChaps { get; set; }
        public string novelStatus { get; set; }
        public DateTime last_chap_updated { get; set; }
        public string rating { get; set; }
        public int ranking { get; set; }
        public string human_views { get; set; }
    }

    public struct DehydratedState
    {
        
        public List<Query> queries { get; set; }
    }





    public struct PageProps
    {
        public DehydratedState dehydratedState { get; set; }

    }



    public struct Props
    {
        public PageProps pageProps { get; set; }
        
    }

    public struct Query
    {
        public State state { get; set; }

    }


    public struct BookInfoDeserialized
    {
        public Props props { get; set; }

    }





    public struct State
    {
        public Data data { get; set; }

    }

    public struct Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }



}
