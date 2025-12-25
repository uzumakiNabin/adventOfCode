package day3

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
)

func Part2() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day3\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	batteryBanks := re.Split(input, -1)

	sum := 0

	for _, bank := range batteryBanks {
		batteries := []rune(bank)
		highestJoltageStr := ""
		remStr := string(batteries)
		for i := 1; i <= 12; i++ {
			high, rem := getHighestNumberWithRun(remStr, i)
			remStr = rem
			highestJoltageStr += high
		}
		highestJoltage, err := strconv.Atoi(highestJoltageStr)
		if err != nil {
			fmt.Println("Error parsing input", bank, highestJoltageStr)
			break
		}
		sum += highestJoltage
	}
	fmt.Println(sum)
}

func getHighestNumberWithRun(str string, run int) (string, string) {
	res := "0"
	maxInd := 0
	for i, ch := range str {
		if run < 12 && i == len(str)-(12-run) {
			break
		}
		strch := string(ch)
		if string(strch) > res {
			res = strch
			maxInd = i
		}
	}
	retStr := ""
	if run < 12 {
		retStr = str[(maxInd + 1):]
	}
	return res, retStr
}
