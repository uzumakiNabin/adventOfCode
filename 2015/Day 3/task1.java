import java.io.File;
import java.util.Scanner;

public class task1{
    public static void main(String[] args){
        int i,j,x = 100, y = 100, count = 0;
        int[][] houses = new int[200][200];
        String input;
        houses[x][y]++;
        try{
            Scanner sc = new Scanner(new File("input.txt"));
            while(sc.hasNextLine()){
                input = sc.nextLine();
                for(i = 0; i < input.length(); i++){
                    if(x == 1 || y == 1){
                        System.out.println("Array almost out of bound");
                        break;
                    }
                    switch(input.charAt(i)){
                        case '<':
                            x--;
                            houses[x][y]++;
                            break;
                        case '>':
                            x++;
                            houses[x][y]++;
                            break;
                        case '^':
                            y++;
                            houses[x][y]++;
                            break;
                        case 'v':
                            y--;
                            houses[x][y]++;
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
            System.out.println("Exception found: " + e);
        }
    }
}