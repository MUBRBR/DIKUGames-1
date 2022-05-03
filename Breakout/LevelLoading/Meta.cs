using System.Text;

namespace LevelLoading {
    public class Meta : IFileReader {
        private static List<Tuple<String, String>> meta = default!;

        public Meta() {
            meta = new List<Tuple<String, String>>();
        }
        public static List<Tuple<String, String>> Reader(String fileName) {
            List<String> file = new List<String>(File.ReadAllLines(fileName));
                foreach (String line in file) {
                    String wl = new String(""); // wrong line
                    switch (line) {
                        case (("Map/") or ("Meta/") or ("Legend/")):
                            break;
                        case ("Map:") or (("Meta:") or ("Legend:")):
                            wl = line;
                            break;
                        default:
                            switch (wl) {
                                case "Meta:":
                                    var builder1 = new StringBuilder();
                                    var builder2 = new StringBuilder();
                                    foreach (Char c in line) {
                                        Char wrongCharacter = default!;
                                        if (c != ':') {
                                            if (wrongCharacter == ':') {
                                                builder1.Append(c);
                                            }
                                            else {
                                                builder2.Append(c);
                                            }
                                        }
                                        else {
                                            wrongCharacter = ':';
                                        }
                                        meta.Add(Tuple.Create(builder1.ToString(), builder2.ToString()));
                                    }
                                    break;
                                default:
                                    break;
                            }
                            
                        break;
                    }
                }
                return  meta;
        }
    }
}