import java.io.File;
import java.util.Scanner;

public class task2{
    public static void main(String[] args){
        String input;
        String[] instruction = new String[5];
        int i, j, start_x, start_y, end_x, end_y, brightness = 0;
        int[][] lightGrid = new int[1000][1000];
        for(i = 0; i < 1000; i++){
            for(j = 0; j < 1000; j++){
                lightGrid[i][j] = 0;
            }
        }
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            while(sc.hasNextLine()){
                input = sc.nextLine();
                instruction = input.split(" ");
                if(instruction.length == 5){
                    start_x = Integer.parseInt(instruction[2].split(",")[0]);
                    start_y = Integer.parseInt(instruction[2].split(",")[1]);
                    end_x = Integer.parseInt(instruction[4].split(",")[0]);
                    end_y = Integer.parseInt(instruction[4].split(",")[1]);
                    if(instruction[1].equals("on")){
                        for(i = start_x; i <= end_x; i++){
                            for(j = start_y; j <= end_y; j++){
                                lightGrid[i][j]++;
                            }
                        }
                    }
                    else{
                        for(i = start_x; i <= end_x; i++){
                            for(j = start_y; j <= end_y; j++){
                                if(lightGrid[i][j] > 0){
                                    lightGrid[i][j]--;
                                }
                            }
                        }
                    }
                }
                else{
                    start_x = Integer.parseInt(instruction[1].split(",")[0]);
                    start_y = Integer.parseInt(instruction[1].split(",")[1]);
                    end_x = Integer.parseInt(instruction[3].split(",")[0]);
                    end_y = Integer.parseInt(instruction[3].split(",")[1]);
                    for(i = start_x; i <= end_x; i++){
                        for(j = start_y; j <= end_y; j++){
                            lightGrid[i][j] += 2;
                        }
                    }
                }
            }
            for(i = 0; i < 1000; i++){
                for(j = 0; j < 1000; j++){
                    brightness += lightGrid[i][j];
                }
            }
            System.out.println("Total brightness is " + brightness);
        }
        catch(Exception e){
            System.out.println("Exception catched: " + e);
        }
    }
}