import java.io.File;
import java.util.Scanner;

public class task2{
    public static void main(String[] args){
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            int total = 0;
            int a, b, c, pr1, pr2, pr3;
            String[] dimensions;
            while(sc.hasNextLine()){
                String input = sc.nextLine().trim();
                dimensions = input.split("x", -1);
                a = Integer.parseInt(dimensions[0]);
                b = Integer.parseInt(dimensions[1]);
                c = Integer.parseInt(dimensions[2]);
                pr1 = 2 * (a + b);
                pr2 = 2 * (b + c);
                pr3 = 2 * (c + a);
                total += (a * b * c); //ribbon for bow
                total += findLowest(pr1, pr2, pr3);  //ribbon for wrapping
            }
            System.out.println("Total amount of ribbon needed is " + total);
        }
        catch (Exception e){
            System.out.println(e);
        }
    }

    public static int findLowest(int a, int b, int c){
        if(a < b){
            if(a < c){
                return a;
            }
            else{
                return c;
            }
        } 
        else{
            if(b < c){
                return b;
            }
            else{
                return c;
            }
        }
    }
}