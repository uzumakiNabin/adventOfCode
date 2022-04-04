import java.io.File;
import java.util.Scanner;

public class task1{
    public static void main(String[] args){
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            int total = 0;
            int a, b, c, area1, area2, area3;
            String[] dimensions;
            while(sc.hasNextLine()){
                String input = sc.nextLine().trim();
                dimensions = input.split("x", -1);
                a = Integer.parseInt(dimensions[0]);
                b = Integer.parseInt(dimensions[1]);
                c = Integer.parseInt(dimensions[2]);
                area1 = a * b;
                area2 = b * c;
                area3 = c * a;
                total += ((2 * area1) + (2 * area2) + (2 * area3));
                total += findLowest(area1, area2, area3);
            }
            System.out.println("Total amount of wrapper paper needed is " + total);
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