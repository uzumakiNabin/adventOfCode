package day11

import (
	"fmt"
	"os"
	"regexp"
	"strings"
)

type Device struct {
	name    string
	outputs []*Device
}

func Part1() {
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

	fmt.Println(findPathCountFromTo(devices, "svr", "fft"))
}

func findDevice(lst []*Device, name string) (*Device, bool) {
	for _, itm := range lst {
		if (*itm).name == name {
			return itm, true
		}
	}
	return nil, false
}

func findPathCountFromTo(lst []*Device, start string, end string) int {
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
	return getPathCount(*startDevice, endDevice.name, memo)
}

func getPathCount(device Device, end string, memo map[string]int) int {
	value, ok := memo[device.name]
	if ok {
		return value
	}
	if device.name == end {
		return 1
	}
	if len(device.outputs) < 1 {
		return 0
	}
	res := 0
	for _, output := range device.outputs {
		res += getPathCount(*output, end, memo)
	}
	memo[device.name] = res
	return res
}
