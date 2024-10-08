using NUnit.Framework;
using System;

[TestFixture]
public class SolutionTests
{
    private Solution solution;

    [SetUp]
    public void Setup()
    {
        solution = new Solution();
    }

    [Test]
    public void HasPathSum_NullRoot_ReturnsFalse()
    {
        Assert.IsFalse(solution.HasPathSum(null, 0));
    }

    [Test]
    public void HasPathSum_SingleNodeEqualToTarget_ReturnsTrue()
    {
        TreeNode root = new TreeNode(5);
        Assert.IsTrue(solution.HasPathSum(root, 5));
    }

    [Test]
    public void HasPathSum_SingleNodeNotEqualToTarget_ReturnsFalse()
    {
        TreeNode root = new TreeNode(5);
        Assert.IsFalse(solution.HasPathSum(root, 10));
    }

    [Test]
    public void HasPathSum_TwoNodesWithValidPath_ReturnsTrue()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(4);
        Assert.IsTrue(solution.HasPathSum(root, 9));
    }

    [Test]
    public void HasPathSum_TwoNodesWithInvalidPath_ReturnsFalse()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(4);
        Assert.IsFalse(solution.HasPathSum(root, 10));
    }

    [Test]
    public void HasPathSum_ComplexTreeWithValidPath_ReturnsTrue()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.right = new TreeNode(8);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        Assert.IsTrue(solution.HasPathSum(root, 22));
    }

    [Test]
    public void HasPathSum_ComplexTreeWithInvalidPath_ReturnsFalse()
    {
        TreeNode root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.right = new TreeNode(8);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        Assert.IsFalse(solution.HasPathSum(root, 100));
    }
}
