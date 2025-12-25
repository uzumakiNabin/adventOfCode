package utils

func DeepCopy[T any](s []T) []T {
	cpy := make([]T, len(s))
	copy(cpy, s)
	return cpy
}
