import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class task1 {
    public static void main(String[] args) throws IOException{
        File f = new File("input.txt");
        Scanner sc = new Scanner(f);
        int floor = 0;
        while(sc.hasNextLine()){
            String input = sc.nextLine();
            for (int i = 0; i < input.length(); i++){
                if(input.charAt(i) == '(')
                    floor++;
                else if(input.charAt(i) == ')')
                    floor--;
            }
        }
        System.out.println(floor);
    }
}