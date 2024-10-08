/**
 * Represents a node in a binary tree.
 * @param val - The value of the node.
 * @param left - The left child of the node, or null if there is no left child.
 * @param right - The right child of the node, or null if there is no right child.
 */
class TreeNode {
    val: number
    left: TreeNode | null
    right: TreeNode | null
    constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
        this.val = (val===undefined ? 0 : val)
        this.left = (left===undefined ? null : left)
        this.right = (right===undefined ? null : right)
    }
}


function hasPathSum(root: TreeNode | null, targetSum: number): boolean {
    // Base case: if the root is null, return false
    if (root === null) {
        return false;
    }

    // If it's a leaf node, check if the remaining sum equals the node's value
    if (root.left === null && root.right === null) {
        return targetSum === root.val;
    }

    // Recursively check left and right subtrees
    const remainingSum = targetSum - root.val;
    return hasPathSum(root.left, remainingSum) || hasPathSum(root.right, remainingSum);
}

// Alternative solution using iterative approach with a stack
function hasPathSumIterative(root: TreeNode | null, targetSum: number): boolean {
    if (root === null) {
        return false;
    }

    interface StackNode {
        node: TreeNode;
        currentSum: number;
    }

    const stack: StackNode[] = [{ node: root, currentSum: root.val }];

    while (stack.length > 0) {
        const { node, currentSum } = stack.pop()!;

        if (node.left === null && node.right === null && currentSum === targetSum) {
            return true;
        }

        if (node.right) {
            stack.push({ node: node.right, currentSum: currentSum + node.right.val });
        }

        if (node.left) {
            stack.push({ node: node.left, currentSum: currentSum + node.left.val });
        }
    }

    return false;
}
