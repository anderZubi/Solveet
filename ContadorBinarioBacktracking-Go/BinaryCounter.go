package main
 
import "fmt"
 
func main() {
	BinaryCount(3, "")
}
 
func BinaryCount(n int, result string){
    if n == len(result) {
        fmt.Println(result) 
    } else { 
        BinaryCount(n, result + "0") 
        BinaryCount(n, result + "1") 
    } 
}