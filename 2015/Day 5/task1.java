import java.io.File;
import java.util.Scanner;

public class task1{
    public static void main(String[] args){
        String input, tmp;
        char c;
        int i, v_count = 0, repeat_count = 0, notAllowed_count = 0, nice = 0, naughty = 0;
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            while(sc.hasNextLine()){
                input = sc.nextLine();
                for(i = 0; i < input.length(); i++){
                    c = input.charAt(i);
                    if(c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'){
                        v_count++;
                    }
                    if(i < (input.length() - 1)){
                        if(c == input.charAt(i + 1)){
                            repeat_count++;
                        }
                        tmp = Character.toString(c) + Character.toString(input.charAt(i + 1));
                        if(tmp.equals("ab") || tmp.equals("cd") || tmp.equals("pq") || tmp.equals("xy")){
                            notAllowed_count++;
                        }
                    }
                }
                if(v_count > 2 && repeat_count > 0 && notAllowed_count == 0){
                    nice++;
                    //System.out.println(input + " is nice v_count = " + v_count + " repeat_count = " + repeat_count + " notAllowed_count = " + notAllowed_count);
                }
                else{
                    naughty++;
                    //System.out.println(input + " is naughty v_count = " + v_count + " repeat_count = " + repeat_count + " notAllowed_count = " + notAllowed_count);
                }
                v_count = 0;
                repeat_count = 0;
                notAllowed_count = 0;
            }
        }
        catch(Exception e){
            System.out.println("Exception catched: " + e);
        }
        System.out.println("Number of nice strings is " + nice);
        System.out.println("Number of naughty strings is " + naughty);
    }
}