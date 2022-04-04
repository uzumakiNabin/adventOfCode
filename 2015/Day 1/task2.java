import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class task2 {
    public static void main(String[] args) throws IOException{
        File f = new File("input.txt");
        Scanner sc = new Scanner(f);
        int floor = 0, i = 0;
        while(sc.hasNextLine()){
            String input = sc.nextLine();
            for (i = 0; i < input.length(); i++){
                if(input.charAt(i) == '(')
                    floor++;
                else if(input.charAt(i) == ')')
                    floor--;
                if(floor < 0){
                    System.out.println("First position to enter basement " + (i + 1));
                    break;
                }
            }
        }
        System.out.println("Final position is " + floor);
    }
}