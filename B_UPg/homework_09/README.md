## Example 9.1: Matrix (Program01.cs)

Write the following functions working with a matrix of long integers:
* A function that creates a matrix of specified dimensions filled with elements with random values. Values should be chosen from the interval [-4, +4], which is convenient for further use in other examples.
* A function that saves the specified matrix to a text file. The matrix's dimensions will be stored on the first line, and the subsequent lines will contain individual rows of the matrix.
* A function that reads a matrix from a text file (in the format specified in 1.b).
* A function that creates a transposed matrix (= swapping rows for columns).
* A function that tests whether the given matrix is symmetric. A matrix is symmetric if, for each element located in row r and column s, its value equals the value of the element in row s and column r.
* A function returning an array containing the diagonal of the matrix. The matrix's diagonal consists of elements located in a row with the same ordinal number as the column's ordinal number in which they are located.
* A function testing whether the matrix is upper triangular. That is, the matrix is square, and all elements below the diagonal have a zero value.
* A function returning the ordinal number of the column in which the first non-zero element is located on the specified row. That is, on the specified row, it determines the number of elements with a zero value to the left of the first non-zero element from the left.
* A function testing whether the matrix is stair-stepped. In a stair-stepped matrix, the number of zeros to the left on each row is at least one greater than on the previous row.
* A function testing whether the matrix is an identity matrix. An identity matrix is a square matrix with elements with a value of one on the diagonal, and all other elements have a zero value.
