import java.io.File;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.Set;
import java.util.Map;
import java.util.Iterator;

public class task1{
    public static TreeMap<String, Integer> wireValue = new TreeMap<String, Integer>();

    public static void main(String[] args){
        String input;
        String[] instruction = new String[5];
        int valueOne, valueTwo;
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            while(sc.hasNextLine()){
                input = sc.nextLine();
                instruction = input.split(" ");
                if(instruction.length == 3){
                    wireValue.put(instruction[2], getValue(instruction[0]));
                }
                else if(instruction[0].equals("NOT")){
                    wireValue.put(instruction[3], logicalNot(getValue(instruction[1])));
                }
                else{
                    valueOne = getValue(instruction[0]);
                    valueTwo = getValue(instruction[2]);
                    switch(instruction[1]){
                        case "OR":
                            wireValue.put(instruction[4], (valueOne | valueTwo));
                            break;
                        case "AND":
                            wireValue.put(instruction[4], (valueOne & valueTwo));
                            break;
                        case "LSHIFT":
                            wireValue.put(instruction[4], (valueOne << valueTwo));
                            break;
                        case "RSHIFT":
                            wireValue.put(instruction[4], (valueOne >> valueTwo));
                            break;
                        default:
                            break;
                    }
                }
            }
            Set s = wireValue.entrySet();
            Iterator it = s.iterator();
            while(it.hasNext()){
                Map.Entry me = (Map.Entry)it.next();
                System.out.println(me.getKey() + " : " + me.getValue());
            }
        }
        catch(Exception e){
            System.out.println("Exception catched: " + e);
        }
    }

    public static int toBinary(int d){
        String result = "";
        while(d >= 1){
            result = (d % 2) + result;
            d /= 2;
        }
        return Integer.parseInt(result);
    }

    public static int toDecimal(int b){
        int result = 0;
        String binary = "" + b;
        for(int i = 0; i < binary.length(); i++){
            result += Character.getNumericValue(binary.charAt(i)) * Math.pow(2, (binary.length() - i - 1));
        }
        return result;
    }

    public static boolean isInteger(String str){
        char c = str.charAt(0);
        if(c < '0' || c > '9'){
            return false;
        }
        return true;
    }

    public static int logicalNot(int value){
        String binary = "" + toBinary(value);
        while(binary.length() < 16){
            binary = "0" + binary;
        }
        String n = "";
        int result = 0;
        for(int i = 0; i < binary.length(); i++){
            if(binary.charAt(i) == '0'){
                n += "1";
            }
            else{
                n += "0";
            }
        }
         for(int i = 0; i < n.length(); i++){
            result += Character.getNumericValue(n.charAt(i)) * Math.pow(2, (n.length() - i - 1));
        }
        return result;
    }

    public static int getValue(String str){
        if(isInteger(str)){
            return Integer.parseInt(str);
        }
        else{
            return wireValue.get(str);
        }
    }
}