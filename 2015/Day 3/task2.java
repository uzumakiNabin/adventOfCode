import java.io.File;
import java.util.Scanner;

public class task2{
    public static void main(String[] args){
        int i,j,s_x = 100, s_y = 100,rs_x = 100,rs_y = 100, count = 0;
        int[][] houses = new int[200][200];
        houses[s_x][s_y]++;
        houses[rs_x][rs_y]++;
        System.out.println(houses[100][100]);
        String input;
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            while(sc.hasNextLine()){
                input = sc.nextLine();
                for(i = 1; i < input.length(); i += 2){
                    if(s_x == 0 || s_y == 0){
                        System.out.println("Array almost out of bound");
                        break;
                    }
                    switch(input.charAt(i)){
                        case '<':
                            s_x--;
                            houses[s_x][s_y]++;
                            break;
                        case '>':
                            s_x++;
                            houses[s_x][s_y]++;
                            break;
                        case '^':
                            s_y++;
                            houses[s_x][s_y]++;
                            break;
                        case 'v':
                            s_y--;
                            houses[s_x][s_y]++;
                            break;
                        default:
                            break;
                    }
                }
                for(i = 0; i < input.length(); i += 2){
                    if(rs_x == 0 || rs_y == 0){
                        System.out.println("Array almost out of bound");
                        break;
                    }
                    switch(input.charAt(i)){
                        case '<':
                            rs_x--;
                            houses[rs_x][rs_y]++;
                            break;
                        case '>':
                            rs_x++;
                            houses[rs_x][rs_y]++;
                            break;
                        case '^':
                            rs_y++;
                            houses[rs_x][rs_y]++;
                            break;
                        case 'v':
                            rs_y--;
                            houses[rs_x][rs_y]++;
                            break;
                        default:
                            break;
                    }
                }
            }
            for(i = 0; i < 200; i++){
                for(j = 0; j< 200; j++){
                    if(houses[i][j] > 0){
                        count++;
                    }
                }
            }
            System.out.println("Number of houses with atleast one gift is " + count);
        }
        catch(Exception e){
            System.out.println("Exception catched: " + e);
        }
    }
}