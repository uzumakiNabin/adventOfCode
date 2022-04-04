import java.io.File;
import java.util.Scanner;
import java.util.ArrayList;

public class task2{
    public static void main(String[] args){
        String input, tmp, e1, e2;
        ArrayList<String> pairs = new ArrayList<String>();
        ArrayList<String> threes = new ArrayList<String>();
        char c;
        int i, j, pair_count = 0, letter_repeat = 0, nice = 0, naughty = 0;
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            while(sc.hasNextLine()){
                input = sc.nextLine();
                for(i = 0; i < (input.length() - 1); i++){
                    tmp = input.substring(i, i + 2);
                    pairs.add(tmp);
                }
                for(i = 0; i < pairs.size(); i++){
                    for(j = (i + 1); j < pairs.size(); j++){
                        e1 = pairs.get(i);
                        e2 = pairs.get(j);
                        if(e1.equals(e2) && (j != i + 1)){
                            pair_count++;
                        }
                    }
                }
                pairs.clear();
                for(i = 0; i < (input.length() - 2); i++){
                    tmp = input.substring(i, i + 3);
                    threes.add(tmp);
                }
                for(String three: threes){
                    if(three.charAt(0) == three.charAt(2))
                        letter_repeat++;
                }
                threes.clear();
                if(pair_count > 0 && letter_repeat > 0){
                    nice++;
                    //System.out.println(input + " is nice pair_count = " + pair_count + " letter_repeat = " + letter_repeat);
                }
                else{
                    naughty++;
                    //System.out.println(input + " is naughty pair_count = " + pair_count + " letter_repeat = " + letter_repeat);
                }
                pair_count = 0;
                letter_repeat = 0;
            }
        }
        catch(Exception e){
            System.out.println("Exception catched: " + e);
        }
        System.out.println("Number of nice strings is " + nice);
        System.out.println("Number of naughty strings is " + naughty);
    }
}