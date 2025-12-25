package day3

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
)

func Part1() {
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
		firstHigh, rem := getHighestNumber(string(batteries), true)
		secondHigh, _ := getHighestNumber(rem, false)
		highestJoltageStr := firstHigh + secondHigh
		highestJoltage, err := strconv.Atoi(highestJoltageStr)
		if err != nil {
			fmt.Println("Error parsing input", bank, firstHigh, secondHigh)
			break
		}
		sum += highestJoltage
	}
	fmt.Println(sum)
}

func getHighestNumber(str string, firstRun bool) (string, string) {
	res := "0"
	maxInd := 0
	for i, ch := range str {
		if firstRun && i == len(str)-1 {
			break
		}
		strch := string(ch)
		if string(strch) > res {
			res = strch
			maxInd = i
		}
	}
	retStr := ""
	if firstRun {
		retStr = str[(maxInd + 1):]
	}
	return res, retStr
}
