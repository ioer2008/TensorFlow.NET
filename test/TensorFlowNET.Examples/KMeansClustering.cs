﻿using NumSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow;
using Tensorflow.Clustering;
using TensorFlowNET.Examples.Utility;

namespace TensorFlowNET.Examples
{
    /// <summary>
    /// Implement K-Means algorithm with TensorFlow.NET, and apply it to classify
    /// handwritten digit images.
    /// https://github.com/aymericdamien/TensorFlow-Examples/blob/master/examples/2_BasicModels/kmeans.py
    /// </summary>
    public class KMeansClustering : Python, IExample
    {
        public int Priority => 7;
        public bool Enabled => true;
        public string Name => "K-means Clustering";

        Datasets mnist;
        NDArray full_data_x;
        int num_steps = 50; // Total steps to train
        int batch_size = 1024; // The number of samples per batch
        int k = 25; // The number of clusters
        int num_classes = 10; // The 10 digits
        int num_features = 784; // Each image is 28x28 pixels

        public bool Run()
        {
            // Input images
            var X = tf.placeholder(tf.float32, shape: new TensorShape(-1, num_features));
            //  Labels (for assigning a label to a centroid and testing)
            var Y = tf.placeholder(tf.float32, shape: new TensorShape(-1, num_classes));

            // K-Means Parameters
            var kmeans = new KMeans(X, k, distance_metric: KMeans.COSINE_DISTANCE, use_mini_batch: true);

            // Build KMeans graph
            var training_graph = kmeans.training_graph();

            return false;
        }

        public void PrepareData()
        {
            mnist = MnistDataSet.read_data_sets("mnist", one_hot: true);
            full_data_x = mnist.train.images;
        }
    }
}
