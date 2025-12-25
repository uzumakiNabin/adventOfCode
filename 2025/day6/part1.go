package day6

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
	"strings"
)

func Part1() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day6\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	lines := re.Split(input, -1)
	signs := strings.Fields(lines[len(lines)-1])
	lines = lines[0:(len(lines) - 1)]
	var linesInt [][]int

	for _, line := range lines {
		nums := strings.Fields(line)
		lineInt := make([]int, len(nums))
		for i, n := range nums {
			lineInt[i], _ = strconv.Atoi(n)
		}
		linesInt = append(linesInt, lineInt)
	}
	total := 0

	for i := range linesInt[0] {
		var nums []int
		for _, line := range linesInt {
			nums = append(nums, line[i])
		}
		total += performMath(nums, signs[i])
	}

	fmt.Println(total)
}

func performMath(nums []int, sign string) int {
	var res int
	switch sign {
	case "+":
		res = 0
		for _, n := range nums {
			res += n
		}
	case "-":
		res = 0
		for _, n := range nums {
			res -= n
		}
	case "*":
		res = 1
		for _, n := range nums {
			res *= n
		}
	default:
		break
	}
	return res
}
