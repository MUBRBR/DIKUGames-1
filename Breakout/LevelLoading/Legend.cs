using System.Text;

namespace LevelLoading {
    public class Legend : IFileReader {
        public List<Tuple<String, String>> legendData {get; private set;}

        public Legend() {
            legendData = new List<Tuple<String, String>>();
        }
        public List<Tuple<String, String>> Reader(String fileName) {
            List<String> file = new List<String>(File.ReadAllLines(fileName));
                
            String wl = new String(""); // wrong line
            foreach (String line in file) {
                switch (line) {
                    case (("Map/") or ("Meta/") or ("Legend/")):
                        break;
                    case ("Map:") or (("Meta:") or ("Legend:") or ("\n")):
                        wl = line;
                        break;
                    default:
                        switch (wl) {
                            case "Legend:":
                                var builder1 = new StringBuilder();
                                var builder2 = new StringBuilder();
                                Char wrongCharacter = default!;
                                foreach (Char c in line) {
                                    if (c != ')' && c != ' ') {
                                        if (wrongCharacter != ')') {
                                            builder1.Append(c);
                                        }
                                        else {
                                            builder2.Append(c);
                                        }
                                    }
                                    else {
                                        wrongCharacter = ')';
                                    }
                                }
                                legendData.Add(Tuple.Create(builder1.ToString(), builder2.ToString()));
                                break;
                            default:
                                break;
                        }
                        
                    break;
                }
            }
            return legendData;
        }
    }
}