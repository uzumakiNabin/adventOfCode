package day11

import (
	"fmt"
	"os"
	"regexp"
	"strings"
)

func Part2() {
	file, err := os.ReadFile("D:\\Projects\\aoc\\2025\\day11\\input")
	if err != nil {
		fmt.Println("Error opening file:", err)
		return
	}
	input := string(file)
	re := regexp.MustCompile(`\r\n|\n|\r`)
	lines := re.Split(input, -1)

	var devices []*Device

	for _, line := range lines {
		nameAndOutputs := strings.Split(line, ": ")
		if len(nameAndOutputs) != 2 {
			fmt.Printf("error parsing: %s", line)
			break
		}
		deviceName := nameAndOutputs[0]
		outputs := strings.Fields(strings.TrimSpace(nameAndOutputs[1]))
		device, existsDevice := findDevice(devices, deviceName)
		if !existsDevice {
			device = &Device{name: deviceName}
			devices = append(devices, device)
		}
		for _, output := range outputs {
			outputDevice, existsOutput := findDevice(devices, output)
			if !existsOutput {
				outputDevice = &Device{name: output}
				devices = append(devices, outputDevice)
			}
			device.outputs = append(device.outputs, outputDevice)
		}
	}

	fmt.Println(findPathCountFromTo_Part2(devices, "svr", "out"))
}

func findPathCountFromTo_Part2(lst []*Device, start string, end string) int {
	startDevice, existsStart := findDevice(lst, start)
	if !existsStart {
		fmt.Println("start not found")
		return 0
	}
	endDevice, existsEnd := findDevice(lst, end)
	if !existsEnd {
		fmt.Println("end not found")
		return 0
	}
	memo := make(map[string]int)
	return getPathCount_Part2(*startDevice, endDevice.name, memo, "00")
}

func getPathCount_Part2(device Device, end string, memo map[string]int, visited string) int {
	value, ok := memo[device.name+visited]
	if ok {
		return value
	}
	if device.name == end {
		if visited == "11" {
			return 1
		} else {
			return 0
		}
	}
	if len(device.outputs) < 1 {
		return 0
	}
	res := 0
	oldVisited := visited
	for _, output := range device.outputs {
		newVisited := visited
		switch output.name {
		case "fft":
			newVisited = "1" + string(visited[1])
		case "dac":
			newVisited = string(visited[0]) + "1"
		}
		res += getPathCount_Part2(*output, end, memo, newVisited)
	}
	memo[device.name+oldVisited] = res
	return res
}
