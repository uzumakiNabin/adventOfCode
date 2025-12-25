package day1

import (
	"fmt"
	"os"
	"regexp"
	"strconv"
)

func Part1() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day1\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	commands := re.Split(input, -1)

	position := 50
	password := 0

	for _, command := range commands {
		if command == "" {
			continue
		}
		rotationDir := string(command[0])
		rotationCount, err := strconv.Atoi(command[1:])
		if err != nil {
			fmt.Println("Error parsing input", command, err)
			break
		}
		rotationCount %= 100
		switch rotationDir {
		case "R":
			position += rotationCount
			position %= 100
		case "L":
			position -= rotationCount
			if position < 0 {
				position += 100
			}
		}
		if position == 0 {
			password++
		}
	}
	fmt.Println(password)
}
