var sys = arbor.ParticleSystem();
sys.parameters({ stiffness: 900, repulsion: 2000, gravity: true, dt: 0.015 })
sys.renderer = Renderer("#sitemap");


var Node = sys.addNode('VNWEBSUMMIT', { 'color': 'orange', 'shape': 'dot', 'label': 'VN WEB SUMMIT' });
var dichvu1 = sys.addNode('dichvu1', { 'color': 'silver', 'shape': 'dot', 'label': 'Mobile' });
var dichvu2 = sys.addNode('dichvu2', { 'color': 'silver', 'shape': 'dot', 'label': 'Web' });
sys.addEdge(Node, dichvu1);
sys.addEdge(Node, dichvu2);
