
using UnityEngine;

public static class GaussianSmoothing
{
        public static float[,] Smooth(float[,] matrix, float sigma)
        {
                int width = matrix.GetLength(0);
                int height = matrix.GetLength(1);
                float[,] smoothedMatrix = new float[width, height];

                float[,] kernel = GenerateGaussianKernel(sigma);

                int kernelSize = kernel.GetLength(0);
                int kernelOffset = kernelSize / 2;

                // Apply Gaussian smoothing to each pixel in the matrix
                for (int x = 0; x < width; x++)
                {
                        for (int y = 0; y < height; y++)
                        {
                                float smoothedValue = 0f;

                                // Convolve the kernel with the matrix around the current pixel
                                for (int i = 0; i < kernelSize; i++)
                                {
                                        for (int j = 0; j < kernelSize; j++)
                                        {
                                                int posX = Mathf.Clamp(x + i - kernelOffset, 0, width - 1);
                                                int posY = Mathf.Clamp(y + j - kernelOffset, 0, height - 1);

                                                smoothedValue += matrix[posX, posY] * kernel[i, j];
                                        }
                                }

                                smoothedMatrix[x, y] = smoothedValue;
                        }
                }

                return smoothedMatrix;
        }

        private static float[,] GenerateGaussianKernel(float sigma)
        {
                int kernelSize = Mathf.CeilToInt(sigma * 6f);
                if (kernelSize % 2 == 0)
                        kernelSize++; // Ensure odd size

                int kernelOffset = kernelSize / 2;
                float[,] kernel = new float[kernelSize, kernelSize];
                float sum = 0f;

                for (int x = -kernelOffset; x <= kernelOffset; x++)
                {
                        for (int y = -kernelOffset; y <= kernelOffset; y++)
                        {
                                float value = Mathf.Exp(-(x * x + y * y) / (2f * sigma * sigma));
                                kernel[x + kernelOffset, y + kernelOffset] = value;
                                sum += value;
                        }
                }

                // Normalize the kernel
                for (int x = 0; x < kernelSize; x++)
                {
                        for (int y = 0; y < kernelSize; y++)
                        {
                                kernel[x, y] /= sum;
                        }
                }

                return kernel;
        }
}