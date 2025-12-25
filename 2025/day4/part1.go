package day4

import (
	"fmt"
	"os"
	"regexp"
)

func Part1() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day4\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	rows := re.Split(input, -1)

	count := 0
	ROLL := "@"

	for y, row := range rows {
		for x, item := range row {
			if string(item) != ROLL {
				continue
			}
			adjCount := 0
			if y > 0 && x > 0 && string(string(rows[y-1])[x-1]) == ROLL {
				adjCount++
			}
			if y > 0 && string(string(rows[y-1])[x]) == ROLL {
				adjCount++
			}
			if y > 0 && x < len(row)-1 && string(string(rows[y-1])[x+1]) == ROLL {
				adjCount++
			}
			if x < len(row)-1 && string(string(rows[y])[x+1]) == ROLL {
				adjCount++
			}
			if x < len(row)-1 && y < len(rows)-1 && string(string(rows[y+1])[x+1]) == ROLL {
				adjCount++
			}
			if y < len(rows)-1 && string(string(rows[y+1])[x]) == ROLL {
				adjCount++
			}
			if y < len(rows)-1 && x > 0 && string(string(rows[y+1])[x-1]) == ROLL {
				adjCount++
			}
			if x > 0 && string(string(rows[y])[x-1]) == ROLL {
				adjCount++
			}
			if adjCount < 4 {
				count++
			}
		}
	}
	fmt.Println(count)
}
