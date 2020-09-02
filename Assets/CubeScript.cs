using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{
    public Shader shader;
    public Texture texture; // For use with PhongShaderTex (Q6)
    public PointLight pointLight;

    // Use this for initialization
    void Start()
    {
        // Add a MeshFilter component to this entity. This essentially comprises of a
        // mesh definition, which in this example is a collection of vertices, colours 
        // and triangles (groups of three vertices). 
        MeshFilter cubeMesh = this.gameObject.AddComponent<MeshFilter>();
        cubeMesh.mesh = this.CreateCubeMesh();

        // Add a MeshRenderer component. This component actually renders the mesh that
        // is defined by the MeshFilter component.
        MeshRenderer renderer = this.gameObject.AddComponent<MeshRenderer>();
        renderer.material.shader = shader;
        renderer.material.mainTexture = texture;
    }

    // Called each frame
    void Update()
    {
        // Get renderer component (in order to pass params to shader)
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        // Pass updated light positions to shader
        renderer.material.SetColor("_PointLightColor", this.pointLight.color);
        renderer.material.SetVector("_PointLightPosition", this.pointLight.GetWorldPosition());
    }

    // Method to create a cube mesh with coloured vertices
    Mesh CreateCubeMesh()
    {
        Mesh m = new Mesh();
        m.name = "Cube";

        // Define the vertices. These are the "points" in 3D space that allow us to
        // construct 3D geometry (by connecting groups of 3 points into triangles).
        m.vertices = new[] {
            new Vector3(-1.0f, 1.0f, -1.0f), // Top
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, -1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f), // Bottom
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f), // Left
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),

            new Vector3(1.0f, -1.0f, -1.0f), // Right
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),

            new Vector3(-1.0f, 1.0f, 1.0f), // Front
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            new Vector3(-1.0f, 1.0f, -1.0f), // Back
            new Vector3(1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f)
        };

        // Define the vertex colours
        m.colors = new[] {
            Color.red, // Top
            Color.red,
            Color.red,
            Color.red,
            Color.red,
            Color.red,

            Color.red, // Bottom
            Color.red,
            Color.red,
            Color.red,
            Color.red,
            Color.red,

            Color.yellow, // Left
            Color.yellow,
            Color.yellow,
            Color.yellow,
            Color.yellow,
            Color.yellow,

            Color.yellow, // Right
            Color.yellow,
            Color.yellow,
            Color.yellow,
            Color.yellow,
            Color.yellow,

            Color.blue, // Front
            Color.blue,
            Color.blue,
            Color.blue,
            Color.blue,
            Color.blue,

            Color.blue, // Back
            Color.blue,
            Color.blue,
            Color.blue,
            Color.blue,
            Color.blue
        };

        // Define normals for each of the six faces of the cube
        /*Vector3 topNormal = new Vector3(0.0f, 1.0f, 0.0f);
        Vector3 bottomNormal = new Vector3(0.0f, -1.0f, 0.0f);
        Vector3 leftNormal = new Vector3(-1.0f, 0.0f, 0.0f);
        Vector3 rightNormal = new Vector3(1.0f, 0.0f, 0.0f);
        Vector3 frontNormal = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 backNormal = new Vector3(0.0f, 0.0f, -1.0f);

        m.normals = new[] {
            topNormal, // Top
            topNormal,
            topNormal,
            topNormal,
            topNormal,
            topNormal,

            bottomNormal, // Bottom
            bottomNormal,
            bottomNormal,
            bottomNormal,
            bottomNormal,
            bottomNormal,

            leftNormal, // Left
            leftNormal,
            leftNormal,
            leftNormal,
            leftNormal,
            leftNormal,

            rightNormal, // Right
            rightNormal,
            rightNormal,
            rightNormal,
            rightNormal,
            rightNormal,
            
            frontNormal, // Front
            frontNormal,
            frontNormal,
            frontNormal,
            frontNormal,
            frontNormal,

            backNormal, // Back
            backNormal,
            backNormal,
            backNormal,
            backNormal,
            backNormal
        };*/

        // UV coordinates (to test Q6 solution)
        m.uv = new[] {
            new Vector2(0.0f, 0.666f), // Top
            new Vector2(0.0f, 1.0f),
            new Vector2(0.333f, 1.0f),
            new Vector2(0.0f, 0.666f),
            new Vector2(0.333f, 1.0f),
            new Vector2(0.333f, 0.666f),

            new Vector2(0.333f, 0.333f), // Bottom
            new Vector2(0.666f, 0.0f),
            new Vector2(0.333f, 0.0f),
            new Vector2(0.333f, 0.333f),
            new Vector2(0.666f, 0.333f),
            new Vector2(0.666f, 0.0f),

            new Vector2(0.666f, 0.666f), // Left
            new Vector2(0.333f, 0.666f),
            new Vector2(0.333f, 1.0f),
            new Vector2(0.666f, 0.666f),
            new Vector2(0.333f, 1.0f),
            new Vector2(0.666f, 1.0f),

            new Vector2(0.0f, 0.333f), // Right
            new Vector2(0.333f, 0.666f),
            new Vector2(0.333f, 0.333f),
            new Vector2(0.0f, 0.333f),
            new Vector2(0.0f, 0.666f),
            new Vector2(0.333f, 0.666f),

            new Vector2(0.666f, 0.666f), // Front
            new Vector2(0.333f, 0.333f),
            new Vector2(0.333f, 0.666f),
            new Vector2(0.666f, 0.666f),
            new Vector2(0.666f, 0.333f),
            new Vector2(0.333f, 0.333f),

            new Vector2(0.0f, 0.333f), // Back
            new Vector2(0.333f, 0.333f),
            new Vector2(0.333f, 0.0f),
            new Vector2(0.0f, 0.0f),
            new Vector2(0.0f, 0.333f),
            new Vector2(0.333f, 0.0f)
        };

        // Vertex normals
        Vector3 frontBottomLeftNormal = (new Vector3(-1.0f, -1.0f, 1.0f)).normalized;
        Vector3 frontTopLeftNormal = (new Vector3(-1.0f, 1.0f, 1.0f)).normalized;
        Vector3 frontTopRightNormal = (new Vector3(1.0f, 1.0f, 1.0f)).normalized;
        Vector3 frontBottomRightNormal = (new Vector3(1.0f, -1.0f, 1.0f)).normalized;
        Vector3 backBottomLeftNormal = (new Vector3(-1.0f, -1.0f, -1.0f)).normalized;
        Vector3 backBottomRightNormal = (new Vector3(1.0f, -1.0f, -1.0f)).normalized;
        Vector3 backTopLeftNormal = (new Vector3(-1.0f, 1.0f, -1.0f)).normalized;
        Vector3 backTopRightNormal = (new Vector3(1.0f, 1.0f, -1.0f)).normalized;

        m.normals = new[] {
            backTopLeftNormal, // Top
            frontTopLeftNormal,
            frontTopRightNormal,
            backTopLeftNormal,
            frontTopRightNormal,
            backTopRightNormal,

            backBottomLeftNormal, // Bottom
            frontBottomRightNormal,
            frontBottomLeftNormal,
            backBottomLeftNormal,
            backBottomRightNormal,
            frontBottomRightNormal,

            backBottomLeftNormal, // Left
            frontBottomLeftNormal,
            frontTopLeftNormal,
            backBottomLeftNormal,
            frontTopLeftNormal,
            backTopLeftNormal,

            backBottomRightNormal, // Right
            frontTopRightNormal,
            frontBottomRightNormal,
            backBottomRightNormal,
            backTopRightNormal,
            frontTopRightNormal,

            frontTopLeftNormal, // Front
            frontBottomRightNormal,
            frontTopRightNormal,
            frontTopLeftNormal,
            frontBottomLeftNormal,
            frontBottomRightNormal,

            backTopLeftNormal, // Back
            backTopRightNormal,
            backBottomRightNormal,
            backBottomLeftNormal,
            backTopLeftNormal,
            backBottomRightNormal
        };

        // Automatically define the triangles based on the number of vertices
        int[] triangles = new int[m.vertices.Length];
        for (int i = 0; i < m.vertices.Length; i++)
            triangles[i] = i;

        m.triangles = triangles;

        // Uncomment the following line to test the Q5 solution:
        //CalculateVertexNormals(m);
        // (Note that the cube is not defined using shared vertices 
        // so there will not be smooth shading at the edges/corners)

        return m;
    }

    // Challenge Q5 solution.
    // The following function updates mesh m with vertex normals, calculated by 
    // averaging the face normals of surrounding triangles. Note that this 
    // function will only average face normals of directly *connected* triangles. 
    // e.g. A vertex in the same spatial location (but separately connected) will 
    // have its own normal. This can lead to hard edges, depending on the mesh
    // layout. The overall behaviour is similar, if not identical, to the built-in
    // Unity mesh helper method Mesh.RecalculateNormals().
    private void CalculateVertexNormals(Mesh m)
    {
        // 1. Initialise a normal "sum" vector for each vertex in the mesh
        Vector3[] normalSums = new Vector3[m.vertices.Length]; // One normal per vertex
        for (int i = 0; i < normalSums.Length; i++)
        {
            normalSums[i] = Vector3.zero;
        }

        // 2. For each triangle, calculate its face normal (cross product)
        // 3. Add that face normal to the 3 corresponding vertex normal sums
        for (int tri = 0; tri < m.triangles.Length / 3; tri++)
        {
            // Get the three vertex positions for a triangle
            Vector3 v1 = m.vertices[tri * 3];
            Vector3 v2 = m.vertices[tri * 3 + 1];
            Vector3 v3 = m.vertices[tri * 3 + 2];

            // Calculate a face normal from its three vertex positions.
            // Note that we ensure this is a unit vector (normalized),
            // otherwise the *magnitude* of the cross product would lead
            // to greater weighting for larger triangles.
            Vector3 faceNormal = Vector3.Cross(v2 - v1, v3 - v1).normalized;

            // Add the face normal to the running sum of each corresponding
            // vertex normal (in order to take an average later on).
            for (int i = 0; i < 3; i++)
            {
                normalSums[tri * 3 + i] += faceNormal;
            }
        }

        // 4. Average (normalise) the normal sums so they are all length 1
        //    At this point, they are no longer "sums", but averages
        for (int i = 0; i < normalSums.Length; i++)
        {
            normalSums[i].Normalize();
        }

        // 5. Update the mesh data with the generated normals
        m.normals = normalSums;
    }
}
