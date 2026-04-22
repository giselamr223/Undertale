import java.io.File;
import java.io.FileWriter;

public class SaveSystem
{
    public static void main(String[] args)
    {
        String json;
        File jarFile;
        File folder;
        File saveFile;
        FileWriter writer;

        if (args.length == 0)
        {
            System.out.println("No JSON received");
            return;
        }

        json = args[0];

        try
        {
            jarFile = new File(SaveSystem.class.getProtectionDomain().getCodeSource().getLocation().toURI());
            folder = jarFile.getParentFile();
            saveFile = new File(folder, "save.json");

            writer = new FileWriter(saveFile);
            writer.write(json);
            writer.close();

            System.out.println("Save created in: " + saveFile.getAbsolutePath());
        }
        catch (Exception e)
        {
            System.out.println("Error: " + e.getMessage());
        }
    }
}