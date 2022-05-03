namespace LevelLoading {
    public class Map : IFileReader {

        public Map() {}
        public List<String> Reader(String fileName) {
            List<String> mapData = new List<String>();
            List<String> file = new List<String>(File.ReadAllLines(fileName));
            String wl = new String(""); // wrong line
            foreach (String line in file) {
                switch (line) {
                    case (("Map:") or ("Meta:") or ("Legend:")):
                        wl = line;
                        break;
                    case (("Map/") or ("Meta/") or ("Legend/") or ("\n")):
                        break;
                    default:
                        switch (wl) {
                            case "Map:":
                                mapData.Add(line);
                                break;
                            default:
                                break;
                        }
                    break;
                }
            }
            return  mapData;
        }
    }
}