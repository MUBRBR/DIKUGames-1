using System;

namespace LevelLoading {
    public interface IFileReader{
        static List<String> Reader(String fileName) => new List<String>();
        // public static void Reader(){
        //     List<String> paths = Directory.EnumerateFiles(@Path.Combine("Assets", "Levels"), "*.txt").ToList();
        //     foreach (String filePath in paths) {
        //         List<String> file = new List<String>(File.ReadAllLines(filePath));
        //         List<String> map = default!;
        //         List<String> meta = default!;
        //         List<String> legend = default!;
        //         List<List<String>> level = default!;
                
        //         foreach (String line in file) {
        //             String wl = new String(""); // wrong line
        //             switch (line) {
        //                 case (("Map:") or ("Meta:") or ("Legend:")):
        //                     wl = line;
        //                     break;
        //                 case (("Map/") or ("Meta/") or ("Legend/")):
        //                     break;
        //                 default:
        //                     switch (wl) {
        //                         case "Map:":
        //                             map.Add(line);
        //                             break;
        //                         case "Meta:":
        //                             meta.Add(line);
        //                             break;
        //                         case "Legend:":
        //                             legend.Add(line);
        //                             break;
        //                     }
                            
        //                 break;
        //             }
        //         }
        //         level = new List<List<String>>{map, meta, legend};
        //         AllLevels.Add(level);
        //     }
            //     AllLevels.Add(Level);
            // }
            // using (List<StreamReader> readers = new List<StreamReader>(@Path.Combine("Assets", "Levels", "*.txt"))) {
            //     string line;
            //     while ((line = reader.ReadLine()) != null)
            //                 {
            //                     list.Add(line);

            //             }

            //         }
        
        // }
        // public static List<List<List<String>>> GetLevel() {
        //     return AllLevels;
        // }
    }
}