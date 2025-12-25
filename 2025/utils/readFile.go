package utils

import (
	"fmt"
	"os"
)

func ReadFile(path string) (string, error) {
	file, err := os.ReadFile(path)
	if err != nil {
		fmt.Println("Error opening file:", err)
		return "", err
	}
	return string(file), nil
}
