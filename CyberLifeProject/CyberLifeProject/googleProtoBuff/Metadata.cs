// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Metadata.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CyberLife.Protobuff.Metadata {

  /// <summary>Holder for reflection information generated from Metadata.proto</summary>
  public static partial class MetadataReflection {

    #region Descriptor
    /// <summary>File descriptor for Metadata.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MetadataReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5NZXRhZGF0YS5wcm90bxIcQ3liZXJMaWZlLlByb3RvYnVmZi5NZXRhZGF0",
            "YRoLcGxhY2UucHJvdG8aDW1hcFNpemUucHJvdG8ipAEKDVN0YXRlTWV0YWRh",
            "dGESDAoEbmFtZRgBIAEoCRINCgV2YWx1ZRgCIAEoARJHCgZwYXJhbXMYAyAD",
            "KAsyNy5DeWJlckxpZmUuUHJvdG9idWZmLk1ldGFkYXRhLlN0YXRlTWV0YWRh",
            "dGEuUGFyYW1zRW50cnkaLQoLUGFyYW1zRW50cnkSCwoDa2V5GAEgASgJEg0K",
            "BXZhbHVlGAIgASgJOgI4ASLkAQoQUGhlbm9tZW5NZXRhZGF0YRIMCgRuYW1l",
            "GAEgASgJEikKBXBsYWNlGAIgASgLMhouQ3liZXJMaWZlLlByb3RvYnVmZi5Q",
            "bGFjZRIQCgh0eXBlTmFtZRgDIAEoCRJSCgpwYXJhbWV0ZXJzGAQgAygLMj4u",
            "Q3liZXJMaWZlLlByb3RvYnVmZi5NZXRhZGF0YS5QaGVub21lbk1ldGFkYXRh",
            "LlBhcmFtZXRlcnNFbnRyeRoxCg9QYXJhbWV0ZXJzRW50cnkSCwoDa2V5GAEg",
            "ASgJEg0KBXZhbHVlGAIgASgJOgI4ASKOAQoQTGlmZUZvcm1NZXRhZGF0YRIp",
            "CgVwbGFjZRgBIAEoCzIaLkN5YmVyTGlmZS5Qcm90b2J1ZmYuUGxhY2USCgoC",
            "aWQYAiABKAMSQwoOc3RhdGVzTWV0YWRhdGEYAyADKAsyKy5DeWJlckxpZmUu",
            "UHJvdG9idWZmLk1ldGFkYXRhLlN0YXRlTWV0YWRhdGEijwEKE0Vudmlyb25t",
            "ZW50TWV0YWRhdGESLQoHbWFwU2l6ZRgBIAEoCzIcLkN5YmVyTGlmZS5Qcm90",
            "b2J1ZmYuTWFwU2l6ZRJJChFwaGVub21lbmFNZXRhZGF0YRgCIAMoCzIuLkN5",
            "YmVyTGlmZS5Qcm90b2J1ZmYuTWV0YWRhdGEuUGhlbm9tZW5NZXRhZGF0YSLA",
            "AgoNV29ybGRNZXRhZGF0YRJOChNlbnZpcm9ubWVudE1ldGFkYXRhGAEgASgL",
            "MjEuQ3liZXJMaWZlLlByb3RvYnVmZi5NZXRhZGF0YS5FbnZpcm9ubWVudE1l",
            "dGFkYXRhElsKEExpZmVGb3JtTWV0YWRhdGEYAiADKAsyQS5DeWJlckxpZmUu",
            "UHJvdG9idWZmLk1ldGFkYXRhLldvcmxkTWV0YWRhdGEuTGlmZUZvcm1NZXRh",
            "ZGF0YUVudHJ5EgwKBG5hbWUYAyABKAkSCwoDYWdlGAQgASgFGmcKFUxpZmVG",
            "b3JtTWV0YWRhdGFFbnRyeRILCgNrZXkYASABKAMSPQoFdmFsdWUYAiABKAsy",
            "Li5DeWJlckxpZmUuUHJvdG9idWZmLk1ldGFkYXRhLkxpZmVGb3JtTWV0YWRh",
            "dGE6AjgBYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::CyberLife.Protobuff.PlaceReflection.Descriptor, global::CyberLife.Protobuff.MapSizeReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CyberLife.Protobuff.Metadata.StateMetadata), global::CyberLife.Protobuff.Metadata.StateMetadata.Parser, new[]{ "Name", "Value", "Params" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, }),
            new pbr::GeneratedClrTypeInfo(typeof(global::CyberLife.Protobuff.Metadata.PhenomenMetadata), global::CyberLife.Protobuff.Metadata.PhenomenMetadata.Parser, new[]{ "Name", "LifeFormPlace", "TypeName", "Parameters" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, }),
            new pbr::GeneratedClrTypeInfo(typeof(global::CyberLife.Protobuff.Metadata.LifeFormMetadata), global::CyberLife.Protobuff.Metadata.LifeFormMetadata.Parser, new[]{ "LifeFormPlace", "Id", "StatesMetadata" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CyberLife.Protobuff.Metadata.EnvironmentMetadata), global::CyberLife.Protobuff.Metadata.EnvironmentMetadata.Parser, new[]{ "MapSize", "PhenomenaMetadata" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CyberLife.Protobuff.Metadata.WorldMetadata), global::CyberLife.Protobuff.Metadata.WorldMetadata.Parser, new[]{ "EnvironmentMetadata", "LifeFormMetadata", "Name", "Age" }, null, null, new pbr::GeneratedClrTypeInfo[] { null, })
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class StateMetadata : pb::IMessage<StateMetadata> {
    private static readonly pb::MessageParser<StateMetadata> _parser = new pb::MessageParser<StateMetadata>(() => new StateMetadata());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<StateMetadata> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CyberLife.Protobuff.Metadata.MetadataReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StateMetadata() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StateMetadata(StateMetadata other) : this() {
      name_ = other.name_;
      value_ = other.value_;
      params_ = other.params_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public StateMetadata Clone() {
      return new StateMetadata(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "value" field.</summary>
    public const int ValueFieldNumber = 2;
    private double value_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public double Value {
      get { return value_; }
      set {
        value_ = value;
      }
    }

    /// <summary>Field number for the "params" field.</summary>
    public const int ParamsFieldNumber = 3;
    private static readonly pbc::MapField<string, string>.Codec _map_params_codec
        = new pbc::MapField<string, string>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForString(18), 26);
    private readonly pbc::MapField<string, string> params_ = new pbc::MapField<string, string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, string> Params {
      get { return params_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as StateMetadata);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(StateMetadata other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.Equals(Value, other.Value)) return false;
      if (!Params.Equals(other.Params)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Value != 0D) hash ^= pbc::ProtobufEqualityComparers.BitwiseDoubleEqualityComparer.GetHashCode(Value);
      hash ^= Params.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Value != 0D) {
        output.WriteRawTag(17);
        output.WriteDouble(Value);
      }
      params_.WriteTo(output, _map_params_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Value != 0D) {
        size += 1 + 8;
      }
      size += params_.CalculateSize(_map_params_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(StateMetadata other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Value != 0D) {
        Value = other.Value;
      }
      params_.Add(other.params_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 17: {
            Value = input.ReadDouble();
            break;
          }
          case 26: {
            params_.AddEntriesFrom(input, _map_params_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class PhenomenMetadata : pb::IMessage<PhenomenMetadata> {
    private static readonly pb::MessageParser<PhenomenMetadata> _parser = new pb::MessageParser<PhenomenMetadata>(() => new PhenomenMetadata());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PhenomenMetadata> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CyberLife.Protobuff.Metadata.MetadataReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PhenomenMetadata() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PhenomenMetadata(PhenomenMetadata other) : this() {
      name_ = other.name_;
      place_ = other.place_ != null ? other.place_.Clone() : null;
      typeName_ = other.typeName_;
      parameters_ = other.parameters_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PhenomenMetadata Clone() {
      return new PhenomenMetadata(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "place" field.</summary>
    public const int PlaceFieldNumber = 2;
    private global::CyberLife.Protobuff.Place place_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CyberLife.Protobuff.Place Place {
      get { return place_; }
      set {
        place_ = value;
      }
    }

    /// <summary>Field number for the "typeName" field.</summary>
    public const int TypeNameFieldNumber = 3;
    private string typeName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string TypeName {
      get { return typeName_; }
      set {
        typeName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "parameters" field.</summary>
    public const int ParametersFieldNumber = 4;
    private static readonly pbc::MapField<string, string>.Codec _map_parameters_codec
        = new pbc::MapField<string, string>.Codec(pb::FieldCodec.ForString(10), pb::FieldCodec.ForString(18), 34);
    private readonly pbc::MapField<string, string> parameters_ = new pbc::MapField<string, string>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<string, string> Parameters {
      get { return parameters_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PhenomenMetadata);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PhenomenMetadata other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (!object.Equals(Place, other.Place)) return false;
      if (TypeName != other.TypeName) return false;
      if (!Parameters.Equals(other.Parameters)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (place_ != null) hash ^= Place.GetHashCode();
      if (TypeName.Length != 0) hash ^= TypeName.GetHashCode();
      hash ^= Parameters.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (place_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Place);
      }
      if (TypeName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(TypeName);
      }
      parameters_.WriteTo(output, _map_parameters_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (place_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Place);
      }
      if (TypeName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(TypeName);
      }
      size += parameters_.CalculateSize(_map_parameters_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PhenomenMetadata other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.place_ != null) {
        if (place_ == null) {
          place_ = new global::CyberLife.Protobuff.Place();
        }
        Place.MergeFrom(other.Place);
      }
      if (other.TypeName.Length != 0) {
        TypeName = other.TypeName;
      }
      parameters_.Add(other.parameters_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            if (place_ == null) {
              place_ = new global::CyberLife.Protobuff.Place();
            }
            input.ReadMessage(place_);
            break;
          }
          case 26: {
            TypeName = input.ReadString();
            break;
          }
          case 34: {
            parameters_.AddEntriesFrom(input, _map_parameters_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class LifeFormMetadata : pb::IMessage<LifeFormMetadata> {
    private static readonly pb::MessageParser<LifeFormMetadata> _parser = new pb::MessageParser<LifeFormMetadata>(() => new LifeFormMetadata());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LifeFormMetadata> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CyberLife.Protobuff.Metadata.MetadataReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LifeFormMetadata() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LifeFormMetadata(LifeFormMetadata other) : this() {
      place_ = other.place_ != null ? other.place_.Clone() : null;
      id_ = other.id_;
      statesMetadata_ = other.statesMetadata_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LifeFormMetadata Clone() {
      return new LifeFormMetadata(this);
    }

    /// <summary>Field number for the "place" field.</summary>
    public const int PlaceFieldNumber = 1;
    private global::CyberLife.Protobuff.Place place_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CyberLife.Protobuff.Place Place {
      get { return place_; }
      set {
        place_ = value;
      }
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 2;
    private long id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "statesMetadata" field.</summary>
    public const int StatesMetadataFieldNumber = 3;
    private static readonly pb::FieldCodec<global::CyberLife.Protobuff.Metadata.StateMetadata> _repeated_statesMetadata_codec
        = pb::FieldCodec.ForMessage(26, global::CyberLife.Protobuff.Metadata.StateMetadata.Parser);
    private readonly pbc::RepeatedField<global::CyberLife.Protobuff.Metadata.StateMetadata> statesMetadata_ = new pbc::RepeatedField<global::CyberLife.Protobuff.Metadata.StateMetadata>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CyberLife.Protobuff.Metadata.StateMetadata> StatesMetadata {
      get { return statesMetadata_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LifeFormMetadata);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LifeFormMetadata other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Place, other.Place)) return false;
      if (Id != other.Id) return false;
      if(!statesMetadata_.Equals(other.statesMetadata_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (place_ != null) hash ^= Place.GetHashCode();
      if (Id != 0L) hash ^= Id.GetHashCode();
      hash ^= statesMetadata_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (place_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Place);
      }
      if (Id != 0L) {
        output.WriteRawTag(16);
        output.WriteInt64(Id);
      }
      statesMetadata_.WriteTo(output, _repeated_statesMetadata_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (place_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Place);
      }
      if (Id != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(Id);
      }
      size += statesMetadata_.CalculateSize(_repeated_statesMetadata_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LifeFormMetadata other) {
      if (other == null) {
        return;
      }
      if (other.place_ != null) {
        if (place_ == null) {
          place_ = new global::CyberLife.Protobuff.Place();
        }
        Place.MergeFrom(other.Place);
      }
      if (other.Id != 0L) {
        Id = other.Id;
      }
      statesMetadata_.Add(other.statesMetadata_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (place_ == null) {
              place_ = new global::CyberLife.Protobuff.Place();
            }
            input.ReadMessage(place_);
            break;
          }
          case 16: {
            Id = input.ReadInt64();
            break;
          }
          case 26: {
            statesMetadata_.AddEntriesFrom(input, _repeated_statesMetadata_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class EnvironmentMetadata : pb::IMessage<EnvironmentMetadata> {
    private static readonly pb::MessageParser<EnvironmentMetadata> _parser = new pb::MessageParser<EnvironmentMetadata>(() => new EnvironmentMetadata());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EnvironmentMetadata> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CyberLife.Protobuff.Metadata.MetadataReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EnvironmentMetadata() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EnvironmentMetadata(EnvironmentMetadata other) : this() {
      mapSize_ = other.mapSize_ != null ? other.mapSize_.Clone() : null;
      phenomenaMetadata_ = other.phenomenaMetadata_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EnvironmentMetadata Clone() {
      return new EnvironmentMetadata(this);
    }

    /// <summary>Field number for the "mapSize" field.</summary>
    public const int MapSizeFieldNumber = 1;
    private global::CyberLife.Protobuff.MapSize mapSize_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CyberLife.Protobuff.MapSize MapSize {
      get { return mapSize_; }
      set {
        mapSize_ = value;
      }
    }

    /// <summary>Field number for the "phenomenaMetadata" field.</summary>
    public const int PhenomenaMetadataFieldNumber = 2;
    private static readonly pb::FieldCodec<global::CyberLife.Protobuff.Metadata.PhenomenMetadata> _repeated_phenomenaMetadata_codec
        = pb::FieldCodec.ForMessage(18, global::CyberLife.Protobuff.Metadata.PhenomenMetadata.Parser);
    private readonly pbc::RepeatedField<global::CyberLife.Protobuff.Metadata.PhenomenMetadata> phenomenaMetadata_ = new pbc::RepeatedField<global::CyberLife.Protobuff.Metadata.PhenomenMetadata>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::CyberLife.Protobuff.Metadata.PhenomenMetadata> PhenomenaMetadata {
      get { return phenomenaMetadata_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EnvironmentMetadata);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EnvironmentMetadata other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(MapSize, other.MapSize)) return false;
      if(!phenomenaMetadata_.Equals(other.phenomenaMetadata_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (mapSize_ != null) hash ^= MapSize.GetHashCode();
      hash ^= phenomenaMetadata_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (mapSize_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(MapSize);
      }
      phenomenaMetadata_.WriteTo(output, _repeated_phenomenaMetadata_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (mapSize_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MapSize);
      }
      size += phenomenaMetadata_.CalculateSize(_repeated_phenomenaMetadata_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EnvironmentMetadata other) {
      if (other == null) {
        return;
      }
      if (other.mapSize_ != null) {
        if (mapSize_ == null) {
          mapSize_ = new global::CyberLife.Protobuff.MapSize();
        }
        MapSize.MergeFrom(other.MapSize);
      }
      phenomenaMetadata_.Add(other.phenomenaMetadata_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (mapSize_ == null) {
              mapSize_ = new global::CyberLife.Protobuff.MapSize();
            }
            input.ReadMessage(mapSize_);
            break;
          }
          case 18: {
            phenomenaMetadata_.AddEntriesFrom(input, _repeated_phenomenaMetadata_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class WorldMetadata : pb::IMessage<WorldMetadata> {
    private static readonly pb::MessageParser<WorldMetadata> _parser = new pb::MessageParser<WorldMetadata>(() => new WorldMetadata());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WorldMetadata> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CyberLife.Protobuff.Metadata.MetadataReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WorldMetadata() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WorldMetadata(WorldMetadata other) : this() {
      environmentMetadata_ = other.environmentMetadata_ != null ? other.environmentMetadata_.Clone() : null;
      lifeFormMetadata_ = other.lifeFormMetadata_.Clone();
      name_ = other.name_;
      age_ = other.age_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WorldMetadata Clone() {
      return new WorldMetadata(this);
    }

    /// <summary>Field number for the "environmentMetadata" field.</summary>
    public const int EnvironmentMetadataFieldNumber = 1;
    private global::CyberLife.Protobuff.Metadata.EnvironmentMetadata environmentMetadata_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::CyberLife.Protobuff.Metadata.EnvironmentMetadata EnvironmentMetadata {
      get { return environmentMetadata_; }
      set {
        environmentMetadata_ = value;
      }
    }

    /// <summary>Field number for the "LifeFormMetadata" field.</summary>
    public const int LifeFormMetadataFieldNumber = 2;
    private static readonly pbc::MapField<long, global::CyberLife.Protobuff.Metadata.LifeFormMetadata>.Codec _map_lifeFormMetadata_codec
        = new pbc::MapField<long, global::CyberLife.Protobuff.Metadata.LifeFormMetadata>.Codec(pb::FieldCodec.ForInt64(8), pb::FieldCodec.ForMessage(18, global::CyberLife.Protobuff.Metadata.LifeFormMetadata.Parser), 18);
    private readonly pbc::MapField<long, global::CyberLife.Protobuff.Metadata.LifeFormMetadata> lifeFormMetadata_ = new pbc::MapField<long, global::CyberLife.Protobuff.Metadata.LifeFormMetadata>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::MapField<long, global::CyberLife.Protobuff.Metadata.LifeFormMetadata> LifeFormMetadata {
      get { return lifeFormMetadata_; }
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 3;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "age" field.</summary>
    public const int AgeFieldNumber = 4;
    private int age_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Age {
      get { return age_; }
      set {
        age_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WorldMetadata);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WorldMetadata other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(EnvironmentMetadata, other.EnvironmentMetadata)) return false;
      if (!LifeFormMetadata.Equals(other.LifeFormMetadata)) return false;
      if (Name != other.Name) return false;
      if (Age != other.Age) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (environmentMetadata_ != null) hash ^= EnvironmentMetadata.GetHashCode();
      hash ^= LifeFormMetadata.GetHashCode();
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Age != 0) hash ^= Age.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (environmentMetadata_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(EnvironmentMetadata);
      }
      lifeFormMetadata_.WriteTo(output, _map_lifeFormMetadata_codec);
      if (Name.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Name);
      }
      if (Age != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Age);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (environmentMetadata_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(EnvironmentMetadata);
      }
      size += lifeFormMetadata_.CalculateSize(_map_lifeFormMetadata_codec);
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Age != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Age);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WorldMetadata other) {
      if (other == null) {
        return;
      }
      if (other.environmentMetadata_ != null) {
        if (environmentMetadata_ == null) {
          environmentMetadata_ = new global::CyberLife.Protobuff.Metadata.EnvironmentMetadata();
        }
        EnvironmentMetadata.MergeFrom(other.EnvironmentMetadata);
      }
      lifeFormMetadata_.Add(other.lifeFormMetadata_);
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Age != 0) {
        Age = other.Age;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (environmentMetadata_ == null) {
              environmentMetadata_ = new global::CyberLife.Protobuff.Metadata.EnvironmentMetadata();
            }
            input.ReadMessage(environmentMetadata_);
            break;
          }
          case 18: {
            lifeFormMetadata_.AddEntriesFrom(input, _map_lifeFormMetadata_codec);
            break;
          }
          case 26: {
            Name = input.ReadString();
            break;
          }
          case 32: {
            Age = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
