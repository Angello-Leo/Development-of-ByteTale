using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project___CGC_Sage
{
    public class WordGenerator
    {
        static string[] normalEnemy = 
        {
            "no","is","if","an","be","of","as","up","we","us","cs","it","or","aw","so","to","oh","ah","pi","ox","me",
            "yin","zap","orb","ult","arc","vex","jaw","nod","ply","rib","dun","hex","kin","rue","pea","sob","roe",
            "elk","oaf","play","door","walk","fish","hand","help","tree","book","ball","home","ring","lens","type",
            "wind","sing","ride","sand","time","rock","look","ship","bear","whom","cold","warm","cozy","snow","heat",
        };

        static string[] normalEnemy2 =
        {   
            "out","oat","lot","mat","mad","cat","dog","sad","joy","tsk","sly","awe","nor","end","yes",
            "yak","tik","fig","coy","amp","vat","lux","sty","fed","tsk","mew","moo","gulp","wisp","jolt",
            "zing","knob","lurk","grit","snub","grim","wyrm","gaze","cove","trot","king","mark","brim","rasp",
            "tint","gush","limp","raze","hack","gawk","mine","slit","yawn","whiz","sift","warp","scum","veil"
        };

        static public string[] splashprojectile = 
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
            "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
            "y", "z",",",".","!","<",">","?"
        };

        static string[] eliteEnemy =
        {
            "thunder" , "fragile" , "loyalty" , "account" , "ancient" , "college" , "campus" , "capable" ,
            "climate" ,  "ability" , "fragile" , "beneath" , "silence" ,"absence" , "combine" , "freedom" ,
            "journey" , "volcano" , "leisure" , "surface","bargain" , "circus" , "blanket" , "cereal" , "texture" ,
            "diagram" , "jealous" ,"message" , "shelter" , "scribble" , "courage" , "request" , "whisper" ,
            "chimney", "christmas" , "mixture" , "kingdom" , "fjord" , "jockey" , "viscount","famine" , "drought" ,
            "grotto" , "ledger" , "ignite" , "kindle" , "malice" ,"mystic" , "scour" , "sconce" , "shroud" ,
            "oracle" , "asylum" , "blight" ,"bizarre" , "blizzard" , "memoir" , "minion" , "mirage" , "rouge" ,
            "thorns" ,"facade" , "bluff" , "poison" , "flame" , "frost" , "chain" , "heir" , "poise" ,"keyboard" ,
            "gyro" , "memories" , "aspire" , "thermal" , "asexual","system" , "program" , "error" , "algorithm" ,
            "array" , "string" , "class" ,"namespace", "boolean" , "convert" , "output" , "packet" , "network" ,
            "private" ,"function" , "binary" , "program" , "execute" , "queue" , "protocol" , "cache" ,"method" ,
            "using" , "object" , "domain" , "network" , "condition" , "else" ,"package" , "execute" , "terminate" ,
            "terminal" , "console" , "parameters" ,"nested" , "continue" , "break"
        };

        static string[] eliteEnemy2 =
        {
           "paragraph" , "whether" , "together" , "determine" , "probable" , "hundred" ,"quotient" , "between" ,
            "student" , "weather" , "solution" , "consonant" , "represent" , "measure" , "possible" , "condition" ,
            "character" , "complete" ,"difficult" , "written" , "question" , "provide" , "electric" , "provide" ,
            "interest" , "populate" , "leave" , "material" , "govern" , "syllable" ,"element" , "symbol" , "though",
            "arrange" , "contain" , "million" , "remember" ,"statement" , "decision"  , "calibrate" , "collateral" ,
            "cumbersome" , "ambrosia" , "ambiguity" , "hyperbole" , "maneuvered" ,"information" , "immolation" ,
            "protection" , "adjacent" , "malevolent" ,"exacerbate" , "allegation" , "descendant" , "indecisive" ,
            "expenditure" ,"expense" , "declarative" , "deviation" , "fascination" , "dissonance" ,"comprehend" ,
            "understand" , "conclave" , "insidious" , "menacing" , "gradient","abuse"
        };

        static public string GetNewNorm()
        {
            Random rand = new Random();
            int index = rand.Next(0, normalEnemy.Length);
            string newWord = normalEnemy[index];
            return newWord;
        }
        static public string GetNewNorm2()
        {
            Random rand = new Random();
            int index = rand.Next(0, normalEnemy2.Length);
            string newWord = normalEnemy2[index];
            return newWord;
        }

        static public string GetNewElite()
        {
            Random rand = new Random();
            int index = rand.Next(0, eliteEnemy.Length);
            string newWord = eliteEnemy[index];
            return newWord;
        }
        static public string GetNewElite2()
        {
            Random rand = new Random();
            int index = rand.Next(0, eliteEnemy2.Length);
            string newWord = eliteEnemy2[index];
            return newWord;
        }
        static public string GetNewDebris()
        {
            Random rand = new Random();
            int index = rand.Next(0, splashprojectile.Length);
            string newWord = splashprojectile[index];
            return newWord;
        }
    }
}
