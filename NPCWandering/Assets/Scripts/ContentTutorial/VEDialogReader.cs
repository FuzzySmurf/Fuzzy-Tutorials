using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The readers job is to strictly read the content.
/// </summary>
public class VEDialogReader
{
    public List<string> content;

    /// <summary>
    /// Use this to keep track of our "current" content count.
    /// </summary>
    private int _curContent = 0;

    public VEDialogReader(List<string> newContent)
    {
        content = newContent;
    }

    /// <summary>
    /// Use this to determine if we are already at max content or not.
    /// </summary>
    public bool isAtMaxContent => content.Count == _curContent;

    /// <summary>
    /// Use this to fetch the 'next' piece of content.
    /// </summary>
    /// <returns></returns>
    public string NextContent()
    {
        //if there is no countent, there is nothing to return.
        if (content.Count == 0) return string.Empty;
        //should prevent the call from over-retrieving content that doesn't exist.
        if (isAtMaxContent) return string.Empty;

        string ret = content.ElementAt(_curContent);
        _curContent++;
        return ret;
    }
}
