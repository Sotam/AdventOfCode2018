namespace AdventOfCode2018
{
    using System.Linq;

    public class Day2 : BaseDay
    {
        public override string SolveA()
        {
            var splittedInput = Helper.SplitInput(Input);

            int found2Times = 0, found3Times = 0;

            foreach (var s in splittedInput)
            {
                var chars = s.ToCharArray();

                if (chars.GroupBy(c => c).Count(x => x.Count() == 2) > 0)
                {
                    found2Times++;
                }

                if (chars.GroupBy(c => c).Count(x => x.Count() == 3) > 0)
                {
                    found3Times++;
                }
            }

            return $"{found2Times * found3Times}";
        }

        public override string SolveB()
        {
            var spittedInput = Helper.SplitInput(Input);

            foreach (var s in spittedInput)
            {
                var inputExcludeS = spittedInput.Where(x => x != s);
                foreach (var s1 in inputExcludeS)
                {
                    var wordMatchCount = 0;
                    var result = "";
                    for (var i = 0; i < s1.Length; i++)
                    {
                        if (s[i] == s1[i])
                        {
                            result += s[i];
                            wordMatchCount++;
                        }
                    }

                    if (wordMatchCount == s1.Length - 1)
                    {
                        return $"words {s} and {s1} differ by one character, result {result}";
                    }
                }
            }

            return "no result.. error..";
        }

        public const string Input = "ovfclbidieyujztrswxmckgnaw\r\npmfqlbimheyujztrswxmckgnap\r\novfqlbidhetujztrswxmcfgnas\r\ngvfqebddheyujztrswxmckgnap\r\novfqlbidheyejztrswxqekgnap\r\novzqlbiqheyujztsswxmckgnap\r\noofqlbidhoyujztoswxmckgnap\r\novfqlbicqeyujztrswxmckgncp\r\novfelbidheyujltrswxmcwgnap\r\novfqlbidheyujzerswxmchgnaf\r\nbvfqlbidheyxjztnswxmckgnap\r\novfqlbidheyugztrswamnkgnap\r\novfqxbidheyujrtrswxmckgbap\r\novfqlbidheyujztrdwxqckgjap\r\novfqebiqheyujztrscxmckgnap\r\navfqlbidheyvjztkswxmckgnap\r\novfqlbidheyujktrswxvskgnap\r\novfqlbidheeujztrswrmckgnae\r\novaqlbidheydjztrswxmchgnap\r\novfqlbodweyujztpswxmckgnap\r\nxvfqlbidhmyujztrswxmykgnap\r\novfqlnidheyujztxswumckgnap\r\novfqlbidhexujztrswxyckgeap\r\novfqlkidhekubztrswxmckgnap\r\novfqlbidheysjzkrsxxmckgnap\r\noxfqebidheyujzprswxmckgnap\r\novfqlbidhetujztrswmmckghap\r\novfclbidhuyujztrswrmckgnap\r\novfqlbijhdyujztrswxmcvgnap\r\novfqlkidhyyujztrswxvckgnap\r\novfqlbiehlyujztrswxhckgnap\r\novfqlbidheyxjjtrsdxmckgnap\r\njvfqlbidheyujztrvwxmckcnap\r\novfvlbidheyujzhrswxmckgnzp\r\novfqnbidhuyujztrswfmckgnap\r\novfrlbidheyujztpswxmckgnat\r\novfqpbidheyujztrywxmcngnap\r\novfqlbidheyumrtrswpmckgnap\r\novfqlbidhoyzjztrswxmckgkap\r\novfqlbibheyuhztrswxmskgnap\r\novfqlbidheybjzfrswxkckgnap\r\novfqnbinheyujztrawxmckgnap\r\novfqlbidheyujztryxxmckgnao\r\novfqzbidheyujztrsuxmckgnpp\r\novfqlbidherujztrswxmckgjsp\r\novfqlbidheyujhtrywxmckgtap\r\noofmlbidheyujftrswxmckgnap\r\novfqlbidhhyujztrawxmckgnbp\r\novfqlbidheyujztrswxeckmnae\r\nlvfqlbidheyujztrswxzckvnap\r\novfqlbidheyujztrswxmckqnfr\r\noffqlbidheyrjztrswxmwkgnap\r\novnqlbidzeyujztmswxmckgnap\r\novfxlbxdheyujztrawxmckgnap\r\novfqmbidheyujztrsaxwckgnap\r\novfqlbidhryzjztrswxmckgcap\r\noffqlbidheyujnthswxmckgnap\r\nogmqlbimheyujztrswxmckgnap\r\novfqlbidheyulztkswxockgnap\r\novfqlbidheyujjtrswxmckypap\r\novfqibidheypjztrswxmskgnap\r\novfqlbwdhyyujztrswxmckgnnp\r\novfqlbidheyujztsvwxmckgkap\r\nodfqlbidoeyujztrswxjckgnap\r\novfqlbodpeyujztrswxmcggnap\r\novfqlbicheyujztrhwxmcagnap\r\novfqlbidheyuaztrgwxmckhnap\r\novfwlbidhyyujztrswtmckgnap\r\novfqlbidgzyujztrswxmckgcap\r\novnqlbcdheyujztrswxmckgnup\r\novfqlbieheyujrtrsdxmckgnap\r\novfqlbidkeyujztrswfmckgnqp\r\novfqlbidtekujztrswxsckgnap\r\novfklbedheyujztrscxmckgnap\r\novfqltivhnyujztrswxmckgnap\r\novfqlbidheyuvuyrswxmckgnap\r\novfqlbidheyjjrtrcwxmckgnap\r\nojfqlbidheyujztrswxmckguvp\r\novfqlbidheiqjqtrswxmckgnap\r\nivfqlfidheyujatrswxmckgnap\r\ncvfqlbidheyujgtrswxmckgnrp\r\novfclbidheeujztrswxmckgnaw\r\novfqlbhdheyujztrswvmcklnap\r\novfqcbidheyvjztaswxmckgnap\r\novgqlbijheyujztrswxvckgnap\r\ngvfqlbidheyujvtrswxmckgnaj\r\novfqlbidheyujztrdwxmcggnvp\r\ncvfqlbidheyujgtrswxmckqnap\r\novfqlbrdheyqjztrswxmckgnaj\r\novfqlbidheyujzjrswbmcrgnap\r\novfqlbvdheyujxtrswxvckgnap\r\novaqlbidheyujctrswxmbkgnap\r\novfqlbidheyujztgdwxvckgnap\r\novfqlbidhevujztrssxmwkgnap\r\nrvfqlbidheyujztrzwxmckhnap\r\novfqmbidheysjztrswxmikgnap\r\novfqlbidheiujztrsdxuckgnap\r\novfqlbidheyveztrswxmckgnah\r\novfqnbiaheytjztrswxmckgnap\r\novfqlbidnayujhtrswxmckgnap\r\novfqlbidheyujztnswxdckgnag\r\novfqlbidheyuyztrswxmzzgnap\r\novfqlbiohexujzthswxmckgnap\r\nlvfqlbidheyujztcswxxckgnap\r\novuqlbidhfxujztrswxmckgnap\r\novfqluidheyujotrswxmrkgnap\r\novfalbidheyujztrswxhckgngp\r\nohjqlbidheyujztrswumckgnap\r\novfqxbidhecujztrspxmckgnap\r\novfqcbidheyusztrpwxmckgnap\r\nfvfwlbidheyujztrswxmcxgnap\r\novfqlbidhxyplztrswxmckgnap\r\novfqlbidheyujftrswxdckgrap\r\novfqlepdheyujztrswxmckgnjp\r\nojjqlbidhuyujztrswxmckgnap\r\novfqlbwdheyujztrswxmcggeap\r\novfqlbidheyujltrscxkckgnap\r\noifqibidheyujztrswxjckgnap\r\novfqlbigheyujztrswdmcqgnap\r\novfqlbieheyujztrswxzzkgnap\r\novfqlbidheyujztrswmmcgbnap\r\novfqlbidhnyujzerswxmkkgnap\r\novfqdbinheyujztrswxeckgnap\r\noveqlbidheyujztrswhmckgnab\r\novfqkbytheyujztrswxmckgnap\r\novfqlbidheyujstsswxmcklnap\r\novfimbidheyujztrewxmckgnap\r\novfqebidhequjztrnwxmckgnap\r\novfqlbidheyukztrswxmckunwp\r\noifqlbidheyuwztrswxmckgnao\r\novfqlbidweyufztrswxmckgtap\r\nevfqlbidheyujztrswxsckvnap\r\nsvbqlbidheyujztrsaxmckgnap\r\novfqlbidheyaoztrswxmckjnap\r\novfqllidheyujztrswxmckynhp\r\nohfqlbidheyujatrswtmckgnap\r\nomfjlfidheyujztrswxmckgnap\r\nxvfqlbidheyujutrswxvckgnap\r\novfqlbidheyukztsswxmzkgnap\r\novfqibidhehujztrswxeckgnap\r\novfqlbydheyuoztrswxmcygnap\r\novfqlbidheyufztrmwxmckvnap\r\novfqrbkdheyujztrswxmckgnaq\r\novfqlbigheyuyztrswxmckgzap\r\novfqlbidheyujztrsjxmcnnnap\r\nuvfqlbipheyujztrswxmckgnay\r\novfqlbddneyujbtrswxmckgnap\r\ntvfqlbidheyujztrswxpckgeap\r\novfqlbidheyuiztrhwxmckznap\r\novfqlbidheyujzteswxvckgvap\r\navfqlbidheyijzlrswxmckgnap\r\noqfqmbidheyujvtrswxmckgnap\r\novnqlbidneyujztrswxmckxnap\r\novfqlbidfeyujztrswxqckgncp\r\novfaybidheyujztrswxrckgnap\r\novfqlbidhemujzarnwxmckgnap\r\novfqlwidheyujctrsfxmckgnap\r\novtelbidheysjztrswxmckgnap\r\novfqlbidheyujztrswsmchunap\r\npvfqlbidheyulztrswxmckynap\r\novfqlbzdhezujztfswxmckgnap\r\nozfqibidheyujztrhwxmckgnap\r\novfqlbioheycjztmswxmckgnap\r\novfqleidheyujztoswxmckgnhp\r\novfqlcidhejujztrswnmckgnap\r\neqfqlbidheyujztrswxmrkgnap\r\novfqlbitheywjztrmwxmckgnap\r\novfqlbidheyujptrswnmcggnap\r\noofqlbidhjyujztrswxmcegnap\r\novfqlbidmeyujztrswxmcxgnxp\r\novjhlbidhefujztrswxmckgnap\r\novfqlbidkeyujzarswxmcugnap\r\nhvyqlridheyujztrswxmckgnap\r\novfqlbidheyujxtrswqmckgnpp\r\novfqlbidheyuiztrtsxmckgnap\r\novfqlbidqeyuuztrbwxmckgnap\r\novfqpbidheyujztrswxwekgnap\r\novfqltidheyujztrbwxmckgnab\r\nokfxluidheyujztrswxmckgnap\r\novfplbidheyujztrsaxmckgnax\r\nwvfqlbidheiujztrswxjckgnap\r\novfqlbidheyqjzlrsqxmckgnap\r\novfqlbadheyujztrsxxmckgnop\r\novfqliidheyujzerswvmckgnap\r\novlrlbidheyujztaswxmckgnap\r\ncvzqlbidheyujgtrswxmckqnap\r\novfqlbidheyujzuqswxmckgnnp\r\novfqlsjdheyujztrswxmcklnap\r\novrqlbidheyujztrssrmckgnap\r\novcqlbidheyujztrsmxmcognap\r\novcqlbidheyjjztrswxmckunap\r\novfilbrdhnyujztrswxmckgnap\r\novfqlbodheyujztrswxeckqnap\r\novfqlbidhuyujqtrswxdckgnap\r\novmqlbidheyujderswxmckgnap\r\novfylbidheyajzrrswxmckgnap\r\novfklbidhtyujzjrswxmckgnap\r\nrvfqlbidheyujztcswxcckgnap\r\novfnlyidheyuwztrswxmckgnap\r\novfqlbidhexujztrswxmpktnap\r\novfplbidheyfjztrswhmckgnap\r\noyfqlbidmexujztrswxmckgnap\r\nmvfqlbidhcyujztrawxmckgnap\r\novfqlbidhqyujdtrswxmcbgnap\r\novfqjbidheybjrtrswxmckgnap\r\nozfqlbidhbyujztrswxmckgpap\r\nokfqlbidheyujztrmwxmckhnap\r\novfqlbydheyujzrrswxnckgnap\r\novfqtbidheycjztrswxmckgnah\r\navfqloidheyujztrswxyckgnap\r\novfqlbldteyujzyrswxmckgnap\r\novfqlbpdhedujztpswxmckgnap\r\novfqlbidheyujztrswxucrvnap\r\nocnqlbidheyujztrswxmwkgnap\r\novfqlvidheyujztrswkmckgnlp\r\nevfqlbidheyujzmrswqmckgnap\r\novfqlbidhryujztrcwxmekgnap\r\novfqlbvdheyujztrzwxmcxgnap\r\novfqlridgeyujztrswxmkkgnap\r\nyvfqlbidheyujzthswzmckgnap\r\novfqlbidheyujmtrswxyukgnap\r\novfqlbidheqgjztrswdmckgnap\r\ndvfzlcidheyujztrswxmckgnap\r\njvfqlbidheyujztrswxmczgnae\r\novfqlbzdheyujztrswxyckgnjp\r\novfqlbxdheyujatrswxmcqgnap\r\novftlbldheyujztrewxmckgnap\r\nowfqlbitheyujzyrswxmckgnap\r\novfqlbidheyujztrswxmchgtvp\r\novfqibidheyujzttswxmkkgnap\r\novkqlbodheyujztvswxmckgnap\r\nonfqlbbdheyujztrxwxmckgnap\r\novfqlbidyeysgztrswxmckgnap\r\novfqlbixherujztrswxmcngnap\r\novlqlbidfeyujztrswxgckgnap\r\novfqlbfdheyujztwswumckgnap\r\novfqlbidheeujztrswxmckgkah\r\novfqtbqdheyujztrswmmckgnap\r\nbbfqlbigheyujztrswxmckgnap\r\novfqljidheyujztrswxmwkgnip\r\novfqobidheyujztrsvxmmkgnap\r\novfqlbidheydjvtrswxmckanap\r\novfqlxidheyujztrswgmckgnep\r\njvfqlbidhzyujztrswxmckgnay\r\novfqlbidhkyujztrswxmlkenap\r\novfqobidheyujztrswxmckjnaf\r\novfxlbidheyujztrswxmcbgnac\r\novfqcbidhtyujztrswxmckqnap\r\nozfglbidheyujzvrswxmckgnap\r\novfqlbidheyujztoswxyckcnap";
    }
}
